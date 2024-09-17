import tkinter as tk
from tkinter import messagebox, filedialog
import subprocess
import os

current_directory = os.path.dirname(os.path.abspath(__file__))

# Função para rodar o comando dotnet new
def create_project():
    project_name = entry_project_name.get().strip()
    template_type = combo_template_type.get().strip().lower()
    project_path = entry_project_path.get().strip()

    if not project_name:
        messagebox.showerror("Erro", "Por favor, insira o nome do projeto.")
        return

    if not project_path:
        messagebox.showerror("Erro", "Por favor, escolha o diretório onde o projeto será criado.")
        return

    # Lista de templates
    minha_lista = ['templatehexagonal', 'webapihex']

    # Rodar comandos para instalar os templates
    for item in minha_lista:
        template_path = os.path.join(current_directory, item)
        subprocess.run(f"dotnet new -i {template_path} --force", shell=True, capture_output=True, text=True)
        
    # Monta o comando dotnet new
    command = f"dotnet new {template_type} -n {project_name} --namespace {project_name} --fieldsName {project_name} -o {os.path.join(project_path, project_name)}"

    # Pergunta ao usuário se ele confirma a criação do projeto
    confirm = messagebox.askyesno("Confirmação", f"Criar o projeto '{project_name}' no diretório '{project_path}' com o template '{template_type}'?")
    
    if confirm:
        try:
            # Executa o comando dotnet via subprocess
            result = subprocess.run(command, shell=True, capture_output=True, text=True)

            if result.returncode == 0:
                messagebox.showinfo("Sucesso", f"Projeto '{project_name}' criado com sucesso:\n{result.stdout}")
            else:
                messagebox.showerror("Erro", f"Erro ao criar o projeto:\n{result.stderr}")
        except Exception as e:
            messagebox.showerror("Erro", f"Falha ao executar o comando: {str(e)}")

# Função para escolher o diretório
def select_directory():
    directory = filedialog.askdirectory()
    if directory:
        entry_project_path.delete(0, tk.END)
        entry_project_path.insert(0, directory)

# Função para configurar a interface gráfica
def setup_gui():
    global entry_project_name, combo_template_type, entry_project_path
    
    root = tk.Tk()
    root.title("Gerador de Projeto .NET")

    # Label e TextBox para o nome do projeto
    tk.Label(root, text="Nome do Projeto:").grid(row=0, column=0, padx=10, pady=10)
    entry_project_name = tk.Entry(root, width=30)
    entry_project_name.grid(row=0, column=1, padx=10, pady=10)

    # Label e ComboBox para selecionar o tipo de template
    tk.Label(root, text="Tipo de Template:").grid(row=1, column=0, padx=10, pady=10)
    combo_template_type = tk.StringVar()
    
    minha_lista = ['templatehexagonal', 'webapihex']
    dropdown_template = tk.OptionMenu(root, combo_template_type, *minha_lista)
    dropdown_template.grid(row=1, column=1, padx=10, pady=10)
    combo_template_type.set(minha_lista[0])  # Definir valor padrão

    # Label e TextBox para o caminho do projeto
    tk.Label(root, text="Caminho do Projeto:").grid(row=2, column=0, padx=10, pady=10)
    entry_project_path = tk.Entry(root, width=30)
    entry_project_path.grid(row=2, column=1, padx=10, pady=10)

    # Botão para escolher o diretório
    btn_browse = tk.Button(root, text="Selecionar Diretório", command=select_directory)
    btn_browse.grid(row=2, column=2, padx=10, pady=10)

    # Botão para criar o projeto
    create_button = tk.Button(root, text="Criar Projeto", command=create_project)
    create_button.grid(row=3, column=0, columnspan=3, pady=20)

    root.mainloop()

# Inicia a aplicação
if __name__ == "__main__":
    setup_gui()
