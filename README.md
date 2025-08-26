## O que fazer antes de executar

Estamos usando docker para rodar o banco postgres, devido a isso é necessário ter o docker assim como conseguir executar o docker-compose ou docker compose.

```bash
    docker-compose up
    dotnet watch
    dotnet ef database upgrade
```

Após isso o backend vai estar rodando como esperado. Provavelmente no futuro vamos precisar ter um docker compose fora do repositório do back e apenas um dockerfile para conseguir integrar com o front, mas por enquanto rodamos assim.
