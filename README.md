# Gerador de Projetos .NET com Python

Este projeto contémuma aplicação em Python que facilita a criação de novos projetos .NET com templates dotnet com o básico da arquitetura Hexagonal (ports, core, adapters e tests) e configurações de aplicação (healthCheck, Swagger, Middlewares e etc.), por meio de uma interface gráfica (GUI) criada com Tkinter. A aplicação permite que você selecione o tipo de template que você quer criar o projeto (API e Worker, API, Web e API), insira o nome do projeto e escolha o diretório onde ele será salvo. Internamente, o projeto é gerado usando o comando dotnet new.

## Funcionalidades

- Criação de projetos .NET com os seguintes templates:
  - templateHexagonal
  - 
- Seleção do diretório de destino onde o projeto será criado.
- Interface gráfica amigável para facilitar a criação de novos projetos.

## Requisitos

Certifique-se de que você tem as seguintes dependências instaladas:

- [Python 3.x](https://www.python.org/downloads/)
- [Tkinter](https://docs.python.org/3/library/tkinter.html) (geralmente incluído com Python)
- [SDK do .NET](https://dotnet.microsoft.com/download)

### Como Instalar o SDK do .NET

Você pode instalar o SDK do .NET em seu sistema usando o seguinte link:  
[Download .NET SDK](https://dotnet.microsoft.com/en-us/download/dotnet)

Verifique a instalação executando no terminal:

dotnet --version

## Como Usar

1. Clone este repositório ou baixe o código fonte:

 git clone https://github.com/deborapesantos/project-aspnetcore-generator.git
 cd dotnet-project-generator

2. Execute o script Python:

  python criador-projeto.py

![image](https://github.com/user-attachments/assets/f229536a-7c80-4de6-885e-8e573eb83fea)



 
