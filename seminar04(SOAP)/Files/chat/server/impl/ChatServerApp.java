package chat.server.impl;

import org.systinet.wasp.*;
import org.systinet.wasp.webservice.Registry;

public class ChatServerApp {

	public static void main(String[] args) throws Exception {
		Wasp.startServer("http://localhost:6060");		
		Registry.publish("/ChatService/", ChatService.class);
		System.out.println("Chat server is up an running.");		
	}
}
