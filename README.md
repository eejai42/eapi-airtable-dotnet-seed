# Effortless API Python Seed Project

This project lets you create a python project which can natively
communicate with your Effortless API.

# Installing the tools

## SSoT.me 
SSoT.me `ssotme` is the dynamic package manager which keeps the code up to date

    > npm install ssotme -g

## Git Fork/Clone
Fork this repository - then clone the project locally


    > git clone git@github.com:you/eapi-airtable-python-seed project-xyz
    > cd project-xyz


## Connecting 2 Effortless API

To connect your new repository to your effortless API Endpoint, run these commands

    > ssotme -init name=ProjectXYZ -p amqps=amqps://effortlessapi-rmq.ssot.me/you-project-xyz

This will create a local python sdk for your EffortlesAPI endpoint - allowing you to immediately begin writing code:

    guest = SMQGuest("amqps://effortlessapi-rmq.ssot.me/you-project-xyz")

    payload = StandardPayload()
    payload.EmailAddress = "you@domain.com"
    payload.DemoPassword = "123"

    guest.ValidateTemporaryAccessToken(payload)
