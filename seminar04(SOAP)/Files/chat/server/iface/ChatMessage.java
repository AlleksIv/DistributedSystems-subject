package chat.server.iface;

public class ChatMessage {
	
	public java.util.Date timestamp;
	public long id;		
	public ChatPerson author;	
	public String text;
	
	public ChatMessage() {
		super();
	}

	public ChatMessage(String text, ChatPerson author, long id, java.util.Date timestamp) {
	    this.text = text;
	    this.author = author;
	    this.timestamp = timestamp;
	    this.id = id;
	}
}
