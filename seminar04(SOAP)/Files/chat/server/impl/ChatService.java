package chat.server.impl;
import chat.server.iface.IChatService;
import chat.server.iface.ChatMessage;

public class ChatService implements IChatService {
	
	private SimpleBackendImpl backendImpl;
	
	public ChatService() {
		backendImpl = SimpleBackendImpl.getInstance();
	}

	public void postMessage(String message, String nickname) {
		backendImpl.postMessage(message, nickname);	
	}

	public ChatMessage[] getAllMessages() {
		return backendImpl.getAllMessages();
	}

	public ChatMessage[] getMessagesAfter(long timestamp) {
		return backendImpl.getMessagesAfter(timestamp);
	}

	public long getLastMessageId() {
		return backendImpl.getLastMessageId();
	}
}
