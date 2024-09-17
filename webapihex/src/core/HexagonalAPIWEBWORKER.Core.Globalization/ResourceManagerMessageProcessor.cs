using System.Globalization;
using System.Resources;

namespace HexagonalAPIWEBWORKER.Core.Globalization
{
    public class ResourceManagerMessageProcessor : IMessageProcessor
    {
        private readonly ResourceManager resourceManager;

        public ResourceManagerMessageProcessor(ResourceManager resourceManager)
        {
            this.resourceManager = resourceManager;
        }

        public MessageTranslation Translate(CultureInfo culture, string key, object[] parameters)
        {
            try
            {
                object @object = resourceManager.GetObject(key, culture);

                if (@object == null)
                {
                    @object = resourceManager.GetObject(parameters[0].ToString(), culture);

                    if (@object == null)
                    {
                        return new MessageTranslation
                        {
                            Translation = null,
                            IsTranslated = false,
                            MessageKey = key,
                            MessageParams = parameters
                        };
                    }
                }

                string translation = @object.ToString();
                if (parameters.Length != 0)
                {
                    translation = MessageFormat(translation, parameters);
                    return new MessageTranslation
                    {
                        Translation = string.Format(culture, translation, parameters),
                        IsTranslated = true,
                        MessageKey = key,
                        MessageParams = parameters
                    };
                }

                return new MessageTranslation
                {
                    Translation = translation,
                    IsTranslated = true,
                    MessageKey = key,
                    MessageParams = parameters
                };
            }
            catch (MissingManifestResourceException)
            {
                return new MessageTranslation
                {
                    Translation = null,
                    IsTranslated = false,
                    MessageKey = key,
                    MessageParams = parameters
                };
            }
        }

        private string MessageFormat(string translation, object[] parameters)
        {
            if (parameters.Any())
                return string.Format("{0}", translation, parameters[0].ToString());

            return translation;
        }
    }

    public class MessageTranslation
    {
        public string Translation { get; set; }

        public bool IsTranslated { get; set; }

        public string MessageKey { get; set; }

        public object[] MessageParams { get; set; }
    }

    public interface IMessageProcessor
    {
        MessageTranslation Translate(CultureInfo culture, string key, object[] parameters);
    }

    public static class MessageTranslatorRegistry
    {
        internal static IMessageTranslatorRegistry cache = new FieldMessageTranslatorRegistry();

        private static ThreadLocal<IMessageTranslatorResolver> threadResolver = new ThreadLocal<IMessageTranslatorResolver>(() => new StaticGlobalMessageTranslatorResolver());

        public static void SetMessageTranslator(MessageTranslator translator)
        {
            cache.SetMessageTranslator(translator);
        }

        public static void SetMessageTranslatorResolver(IMessageTranslatorResolver resolver)
        {
            threadResolver.Value = resolver;
        }

        public static MessageTranslator GetMessageTranslator()
        {
            return threadResolver.Value.GetMessageTranslator();
        }

        public static void SetMessageTranslatorRegistry(IMessageTranslatorRegistry newCache)
        {
            cache = newCache;
        }
    }

    public interface IMessageTranslatorRegistry
    {
        void SetMessageTranslator(MessageTranslator translator);

        MessageTranslator GetMessageTranslator();
    }

    public class MessageTranslator
    {
        private readonly IMessageProcessor processor;

        public CultureInfo Culture { get; private set; }

        public MessageTranslator(CultureInfo defaultCulture, IMessageProcessor processor)
        {
            Culture = defaultCulture;
            this.processor = processor;
        }

        public string Translate(CultureInfo culture, string key, params object[] parameters)
        {
            if (culture == null)
            {
                culture = Culture;
            }

            MessageTranslation messageTranslation = processor.Translate(culture, key, parameters);
            if (messageTranslation.IsTranslated)
            {
                return messageTranslation.Translation;
            }

            return $"?{key}@{culture.ToString()}?";
        }

        public string Translate(string key, params object[] parameters)
        {
            return Translate(Culture, key, parameters);
        }
    }

    public interface IMessageTranslatorResolver
    {
        MessageTranslator GetMessageTranslator();
    }

    public class FieldMessageTranslatorRegistry : IMessageTranslatorRegistry
    {
        private MessageTranslator translator;

        public void SetMessageTranslator(MessageTranslator translator)
        {
            this.translator = translator;
        }

        public MessageTranslator GetMessageTranslator()
        {
            return translator;
        }
    }

    public class StaticGlobalMessageTranslatorResolver : IMessageTranslatorResolver
    {
        public MessageTranslator GetMessageTranslator()
        {
            return MessageTranslatorRegistry.cache.GetMessageTranslator();
        }
    }
}
