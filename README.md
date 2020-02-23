# Effortless API DotNet Seed Project

This project lets you create a dotnet project which can natively
communicate with your Effortless API.

# Installing the tools

## SSoT.me 
SSoT.me `ssotme` is the dynamic package manager which keeps the code up to date

    > npm install ssotme -g

## Git Fork/Clone
Fork this repository - then clone the project locally


    > git clone git@github.com:you/eapi-airtable-dotnet-seed project-xyz
    > cd project-xyz


## Connecting 2 Effortless API

To connect your new repository to your effortless API Endpoint, run these commands

    > ssotme -init -name=YourProject -addSetting amqps=amqps://smqPublic:smqPublic@effortlessapi-rmq.ssot.me/YOUR PROJECT-URL -addSetting dataclasses-namespace=YOUR_PROJECT.Lib.DataClasses

    > code .

    > ssotme -build

The code will start to build in the background, and VSCode will open in the root of the project. 
Use the following instructions to tailor the example for your project.

    1. Open the `DotNet/ConsoleApp1/Program.cs` and replace `YOUR-PROJECT-URL` with the url to your project.
    2. Replace the `admin.GetTABLEXYZ()` with one of your actual tables.  
    2. Replace `payload.TABLEXYZs` with a reference to the table you requested above.
    2. Press F5.

This will create a local dotnet sdk for your EffortlesAPI endpoint - allowing you to immediately begin writing code:

    guest = SMQGuest("amqps://effortlessapi-rmq.ssot.me/you-project-xyz")

    payload = StandardPayload()
    payload.EmailAddress = "you@domain.com"
    payload.DemoPassword = "123"

    guest.ValidateTemporaryAccessToken(payload)
