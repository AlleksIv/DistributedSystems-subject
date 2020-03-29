Distributed Systems Seminars: 3. Remote Method Invocation 
========

https://github.com/xPryds/JavaRMI
--------

Command List:
- */list* : show the list of active channels
- */join* : join a channel and starts to chat
    for command */join* first digit it and then digit the name of the channel



Done on Linux Virtual Machine because it's easier so instruction is for linux too

- Download/clone archive and unpack it to folder

Open a CLI and digit:
`rmiregistry` it's like npm from task 01 but

Then open one terminal for server, as many terminals you want for clients:

`java ChatServer` on terminal for the server

`java ChatClient` on others terminals

You will have to choose a nickname. Simply type on the terminal and press ENTER to send your message, to stop programs press `CTRL-C`

