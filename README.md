# MottuTracker API

Este projeto é uma API RESTful desenvolvida com ASP.NET Core para rastreamento de localização de motos via simulação de dispositivos Bluetooth/Arduino.

## Descrição

A aplicação permite o cadastro de motos e o recebimento automático de localizações simuladas para cada moto cadastrada. Ela se integra a um banco de dados Oracle utilizando Entity Framework Core e expõe endpoints documentados com Swagger (OpenAPI).

---

## Tecnologias Utilizadas

- ASP.NET Core
- Entity Framework Core
- Oracle Database (XE)
- Swagger (Swashbuckle)
- C#
- Simulação com ConsoleApp (`SimuladorLocalizacao`)

---

## Instalação e Execução

## Pré-requisitos

- .NET 8.0 ou superior
- Oracle XE instalado (nome do serviço: `XEPDB1`)
- Visual Studio 2022
- Oracle Developer Tools (opcional)

##  Configuração do Banco

1. Certifique-se de que o Oracle XE está rodando.
2. Atualize a `ConnectionString` no `appsettings.json` do projeto `MottuTrackerAPI`:

```
"ConnectionStrings": {
  "OracleDB": "User Id=SYSTEM;Password=SUASENHA;Data Source=localhost:1521/XEPDB1"
}
```

> Substitua `SUASENHA` pela senha definida na instalação do Oracle.

Obs.: Edite a `ConnectionString` no arquivo `appsettings.json` com os dados corretos do seu Oracle local. 
Substitua `SUASENHA` pela senha que você configurou ao instalar o Oracle Database XE.


---

## Executar API

1. Abra o projeto `MottuTrackerAPI` no Visual Studio.
2. Compile e execute.
3. Acesse via navegador: [https://localhost:xxxxx](https://localhost:xxxxx)  
   A interface Swagger será carregada automaticamente.

---

## Executar Simulador

1. Abra o projeto `SimuladorLocalizacao` no Visual Studio.
2. Compile e execute.
3. Após cadastrar uma nova moto na API (`POST /api/Motos`), o simulador detectará automaticamente a última moto e começará a enviar localizações simuladas para ela a cada 10 segundos.

---

## Endpoints da API

## Motos

- **GET** `/api/Motos` → Lista todas as motos
- **GET** `/api/Motos/{id}` → Detalhes de uma moto
- **POST** `/api/Motos` → Cadastra uma moto
- **PUT** `/api/Motos/{id}` → Atualiza uma moto
- **DELETE** `/api/Motos/{id}` → Remove uma moto

## Localização

- **GET** `/api/Localizacao` → Lista todas as localizações
- **GET** `/api/Localizacao/{id}` → Detalhes de uma localização
- **POST** `/api/Localizacao` → Registra uma nova localização



## Desenvolvido por

Lívia Lopes - RM: 556281

Henrique Pecora - RM: 556612

Santhiago de Gobbi - RM: 98420


