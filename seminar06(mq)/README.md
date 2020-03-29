Distributed Systems Seminars: 6. Message Queues 
=====================================
https://github.com/apache/activemq/tree/master/activemq-web-demo
--------

Building
--------
To build the application:

    $ gradle build

Running
-------
Download the [latest release](http://activemq.apache.org/activemq-5120-release.html) of ActiveMQ.  Untar the file:

    $ tar -xzvf apache-activemq-5.12.0-bin.tar.gz

Run one of the wrappers in local mode:

    $ ./bin/macosx/activemq console

Or for Linux:

    $ ./bin/linux-x86-64/activemq console

After starting ActiveMQ, you can run the chat programs in OTHER terminals.  Each terminal should be set to the JMS example directory.  To run the example, in each terminal type:

    $ java -cp build/libs/simple-jms-example-0.1.jar:: simplejms.CLIDriver TopicCF topic1 {username}

where `{username}` is the user's name.

Then simply type something and press enter.  You should see output like so:

    this is a test
    Received: RJ: this is a test
    exit

Type `exit` when you want to quit.  ActiveMQ can be exited by pressing Ctrl-C.










    Also - i don't have much expirience in Java, so - almost all project is copypasted
