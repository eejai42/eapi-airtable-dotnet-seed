# Effortless API Python Seed Project

This project lets you create a python project which can natively
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

    > ssotme -init -name=PictureSalon -addSetting amqps=amqps://smqPublic:smqPublic@effortlessapi-rmq.ssot.me/YOUR PROJECT-URL -addSetting dataclasses-namespace=YOUR_PROJECT.Lib.DataClasses

    Open the `DotNet/ConsoleApp1/Program.cs` and replace `YOUR-PROJECT-URL` with the url to your project.
    Replace the `admin.GetTABLEXYZ()` with one of your actual tables.  
    Replace `payload.TABLEXYZs` with a reference to the table you requested above.
    Press F5.

This will create a local python sdk for your EffortlesAPI endpoint - allowing you to immediately begin writing code:

    guest = SMQGuest("amqps://effortlessapi-rmq.ssot.me/you-project-xyz")

    payload = StandardPayload()
    payload.EmailAddress = "you@domain.com"
    payload.DemoPassword = "123"

    guest.ValidateTemporaryAccessToken(payload)
