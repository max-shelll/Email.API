# Email Service 

## Table of Contents

- [Getting Started](#getting-started)
  - [Installation](#installation)
  - [Configuration](#configuration)

## Getting Started

### Installation

1. Ensure you have [Docker](https://www.docker.com/products/docker-desktop/) installed.

2. Clone the repository:

   ```bash
   git clone https://github.com/koetee/advanced-auth-ts.git
   ```

### Configuration

located at: `...\Mail.API\Mail.API\appsettings.json`

```env
"EmailConfiguration": {
    "From": "youemail",
    "SmtpServer": "yoursmtpserver",
    "Port": yoursmtpport,
    "Username": "yourusername",
    "Password": "yourpassword",
    "UseSsl": true
  }
```

## Getting Started

1. Build docker image

  ```bash
  docker build -t name .
  ex: docker build -t mail.api . [the dot indicates the directory that contains the DockerFile]
  ```
   
2. Run container ( you need to be at `...\Mail.API\Mail.API` dir and have an active docker )

   ```bash
   docker run -p [view port]:80 -d [name]
   ex: docker run -p 8080:80 -d mail.api
   ```

3. My congratulations, it's working

   ```bask
   swagger: https://[:::]:port/swagger/index.html
   api: https://[:::]:port/api/email/
   ```

## Images:   
![image](https://github.com/max-shelll/Mail.API/assets/101334622/0572190d-353a-4931-ad34-2bbb14ce2987)
