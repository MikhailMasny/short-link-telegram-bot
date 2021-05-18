# LinkShortener [Telegram Bot]

[![.NET](https://github.com/MikhailMasny/short-link-telegram-bot/actions/workflows/dotnetcore.yml/badge.svg)](https://github.com/MikhailMasny/short-link-telegram-bot/actions/workflows/dotnetcore.yml)

The main idea of the web application is to develop a telegram bot for quickly create a short link. This repository can also serve as a template for creating a specific bot with its subsequent publication on the Internet.

## Getting Started

When you start interacting with the Telegram Bot, the user can use the "/ start" command, after which it is enough to follow the instructions and use the bot that performs certain commands and tasks.

## Application settings

For the correct functioning of Telegram Bot, it is necessary to update the [appsettnigs.json](https://github.com/MikhailMasny/short-link-telegram-bot/blob/master/src/Masny.Bot/appsettings.json) file in the root directory of the web project, filled in according to the template below.

```
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "AllowedHosts": "*",
  "Url": "https://your-url-app.herokuapp.com",
  "Token": "your-telegram-token"
}
```

## Deployment Docker container on Heroku

To start the entire infrastructure, you must run the following commands from the project folder:

```
heroku login 
docker build -t short-link-generator-bot .
docker tag short-link-generator-bot registry.heroku.com/short-link-generator-bot/web
heroku container:login
heroku container:push web -a short-link-generator-bot
heroku container:release web -a short-link-generator-bot
```

## Built with

- [Monolithic architecture](https://docs.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/common-web-application-architectures);
- [Docker](https://www.docker.com/);
- [ASP.NET Core 3.1](https://docs.microsoft.com/en-us/aspnet/core/);
- [Telegram Bot](https://www.nuget.org/packages/Telegram.Bot/);
- [is.gd](https://www.nuget.org/packages/is.gd/);

## Author

[Mikhail M.](https://mikhailmasny.github.io/) - Software Engineer;

## License

This project is licensed under the MIT License - see the [LICENSE.md](https://github.com/MikhailMasny/short-link-telegram-bot/blob/master/LICENSE) file for details.
