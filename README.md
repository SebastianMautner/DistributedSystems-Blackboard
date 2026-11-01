# Distributed Blackboard-System
This repo contains an implementation for a Blackboard-system using Apache Thrift.
To demonstrate cross-language support the server was written in c#, whilst the client was written in python.
## Reuqirements
* python and c# (.NET) runtime package/ compilers/ interpreters
* thrift compiler (was built on 0.25.0)
## Usage (Client)
* Add the server's IP in line 10 and port in 11
* Create a python venv in the client folder (python -m venv path/to/venv) (only necessary the first time)
* Activate it using the correct script (the shell should now have (.venv) in its header)
* run
```bash
pip install thrift
```
now you should be able to execute
```bash
python client.py <method(put or get)> <key> <value>
```
## Usage (Server)
* if the nuget thrift package isnt already installed (i think it should already be), run
```powershell
dotnet add package ApacheThrift --version 0.25.0 
```
* run
```powershell
dotnet build
dotnet run
```
to start the server
