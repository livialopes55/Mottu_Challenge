Projeto de DevOps - Challenge FIAP 

-Descrição do Projeto
O objetivo deste projeto é realizar a conteinerização da API MottuTracker, desenvolvida em .NET 8 com Entity Framework Core, e sua publicação na nuvem utilizando uma Máquina Virtual (VM) no Microsoft Azure.
A API está acessível publicamente através da porta 8080, exposta na VM, permitindo acesso via navegador, Swagger ou ferramentas como Postman.

Tecnologias Utilizadas
✔.NET 8
✔C#
✔Entity Framework Core
✔Docker
✔Azure (Máquina Virtual - VM Ubuntu)
✔Git e GitHub para versionamento

-Arquitetura do Projeto

O fluxo consiste em:

O usuário acessa a VM via SSH.
Na VM, os containers Docker executam a API .NET.
A API está exposta na porta 8080, liberada nas regras de segurança da Azure.
Acesso à API ocorre via navegador, Swagger ou ferramentas como Postman.

-Docker - Comandos Utilizados

# Construção da imagem
docker build -t mottutrackerapi .
# Execução do container
docker run -d --network=mottunet -p 8080:5000 --name api mottutrackerapi
# Verificar containers ativos
docker ps

•Dockerfile

# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app
COPY . .
RUN dotnet restore
RUN dotnet publish -c Release -o out
# Etapa de runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .
# Adiciona usuário sem privilégios
RUN adduser --disabled-password appuser
USER appuser
# Expondo porta
EXPOSE 5000
# Executando a API
ENTRYPOINT ["dotnet", "MottuTrackerAPI_Completo.dll"]

- Publicação na Azure
•Criação da Máquina Virtual Ubuntu na Azure.

•Abertura da porta 8080 com o comando:

az network nsg rule create \
  --resource-group MottuResourceGroup \
  --nsg-name MottuVMNSG \
  --name AllowPort8080 \
  --priority 905 \
  --destination-port-ranges 8080 \
  --direction Inbound \
  --access Allow \
  --protocol Tcp \
  --source-address-prefixes '*' \
  --source-port-ranges '*' \
  --destination-address-prefixes '*'

-Evidências do Projeto
•	Criação da Máquina Virtual no Azure:
https://youtu.be/Hb07rnAlP2U
•	Acesso SSH, Docker Build, Docker Run e API funcionando:
https://youtu.be/zbjWDbF-5is?si=UjiF0qiE99kV44LY

-Equipe
Lívia Lopes - RM: 556281
Henrique Pecora - RM: 556612
Santhiago de Gobbi - RM: 98420

-Link do Projeto
GIT: https://github.com/livialopes55/Mottu_Challenge/tree/devops/Devops


-Observações
Conforme orientação do professor, a conteinerização obrigatória é somente da API.
O banco Oracle não foi conteinerizado, seguindo a liberação.

