package chat.server.iface;


public interface IChatService{

	long NO_MESSAGE = -1;
	
	public void postMessage(String message, String nickname);

	ChatMessage[] getAllMessages();
	
	ChatMessage[] getMessagesAfter(long precedingMessageId);

	long getLastMessageId();
	
}
