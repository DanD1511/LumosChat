import { Injectable, signal } from '@angular/core';
import { HubConnection, HubConnectionBuilder } from '@microsoft/signalr';
import { env } from '../../env/env';

export interface ChatMessage {
  user: string;
  text: string;
  time: Date;
  avatar: string;
}

@Injectable({
  providedIn: 'root'
})
export class ChatService {
  private hubConnection: HubConnection | null = null;
  
  messages = signal<ChatMessage[]>([]);
  onlineUsers = signal<string[]>([]);

  constructor() {}

  startConnection(token: string) {
    this.hubConnection = new HubConnectionBuilder()
      .withUrl(env.hubUrl, { accessTokenFactory: () => token })
      .withAutomaticReconnect()
      .build();

    this.hubConnection
      .start()
      .then(() => console.log('🟢 Conectado a SignalR'))
      .catch(err => console.error('🔴 Error SignalR:', err));

    this.hubConnection.on('ReceiveMessage', (user: string, message: string) => {
      const newMsg: ChatMessage = {
        user: user,
        text: message,
        time: new Date(),
        avatar: `https://api.dicebear.com/9.x/avataaars/svg?seed=${user}` 
      };

      this.messages.update(msgs => [...msgs, newMsg]);
    });

    this.hubConnection.on('UpdateUserList', (users: string[]) => {
        console.log('👥 Lista de usuarios actualizada:', users);
        this.onlineUsers.set(users);
    });
  }

  async sendMessage(message: string) {
    if (!this.hubConnection) return;
    await this.hubConnection.invoke('SendMessage', message);
  }

  stopConnection() {
    this.hubConnection?.stop();
  }

  getAvatar(user: string): string {
      return `https://api.dicebear.com/9.x/avataaars/svg?seed=${user}`;
  }
}
