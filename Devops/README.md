# 🚀 MottuTrackerAPI

API desenvolvida em ASP.NET Core para controle, monitoramento e gestão das motos nos pátios da Mottu.

## 📚 Funcionalidades

- CRUD completo de Motos e Localizações
- Integração com Banco de Dados Oracle
- Documentação OpenAPI (Swagger)
- Conteinerizada com Docker
- Deploy em Máquina Virtual Linux no Azure

## 🐳 Executando com Docker

### Build da imagem:

```bash
docker build -t mottutrackerapi .
```

### Executando o container:

```bash
docker run -d -p 5000:80 --name api mottutrackerapi
```

Acesse via navegador:

```
http://localhost:5000/swagger
```

## ☁️ Azure - Deploy na Nuvem

### Provisionamento da VM:

```bash
az group create --name MottuResourceGroup --location eastus
az vm create --resource-group MottuResourceGroup --name MottuVM --image Ubuntu2204 --admin-username azureuser --generate-ssh-keys
az vm open-port --port 5000 --resource-group MottuResourceGroup --name MottuVM
```

### Acessando a VM:

```bash
ssh azureuser@IP_DA_VM
```

### Instalando Docker na VM:

```bash
sudo apt update
sudo apt install -y docker.io
sudo systemctl start docker
sudo systemctl enable docker
sudo usermod -aG docker azureuser
```

### Executando na VM:

```bash
git clone https://github.com/seu-usuario/seu-repositorio.git
cd seu-repositorio
docker build -t mottutrackerapi .
docker run -d -p 5000:80 --name api mottutrackerapi
```

Acesse a API:

```
http://IP_DA_VM:5000/swagger
```

## 🔗 Links Importantes

- 🎥 Link do vídeo no YouTube
- 💻 Link do GitHub

## 🗺️ Arquitetura

Arquitetura da aplicação rodando em uma VM no Azure, usando Docker para a API e Oracle.

## 🗑️ Deletar VM

```bash
az group delete --name MottuResourceGroup --yes --no-wait
```