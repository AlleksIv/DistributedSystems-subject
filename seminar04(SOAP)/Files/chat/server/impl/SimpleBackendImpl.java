package chat.server.impl;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;
import chat.server.iface.ChatMessage;
import chat.server.iface.ChatPerson;
import chat.server.iface.IChatService;

public class SimpleBackendImpl {
	
	private static final SimpleBackendImpl _instance = new SimpleBackendImpl();
	private List messages;
	private ChatMessage lastMessage = null;
	private long lastid = 0;
	
	public SimpleBackendImpl() {
		super();
		messages = new ArrayList(100);
	}

	public static final SimpleBackendImpl getInstance() {
		return _instance;
	}	
	
	synchronized public void postMessage(String message, String nickname) {
		if(message == null) throw 
			new IllegalArgumentException("The message argument to the postMessage method may not be null.");
		if(nickname == null) throw 
			new IllegalArgumentException("The nickname argument to the postMessage method may not be null.");
		ChatPerson author = new ChatPerson();
		lastMessage = new ChatMessage(message, new ChatPerson(nickname), ++lastid, new Date());		
		messages.add(lastMessage);
	}

	public ChatMessage[] getAllMessages() {
		return (ChatMessage[])messages.toArray(new ChatMessage[messages.size()]);
	}

	public ChatMessage[] getMessagesAfter(long id) {
		if(id < 0) throw 			
			new IllegalArgumentException("The id argument to the getChatItemsAfter method may not be negative.");
		//check if there are any newer messages
		if(lastMessage != null && lastMessage.id > id) {	
			int i;
			int j = messages.size();
			for(i = 0; i < j; i++) {
				if(((ChatMessage)messages.get(i)).id > id) {
					if(i == 0) return getAllMessages();
					int length = j - i;
					ChatMessage msgs[] = new ChatMessage[length];
					for(j = 0; j < length; j++) {
						msgs[j] = (ChatMessage)messages.get(i + j); 				
					}
					return msgs;
				}
			}
			//when no new messages found, return an empty array
		}
		return new ChatMessage[0];
	}

	public long getLastMessageId() {
		if(lastMessage == null) return -1;
		return lastMessage.id;
	}

}
