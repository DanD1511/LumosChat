import { Component, inject, OnInit, OnDestroy } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ChatService } from '../../core/services/chat';
import { AuthService } from '../../core/services/auth';
import { Router } from '@angular/router';

@Component({
  selector: 'app-chat',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './chat.html',
  styleUrl: './chat.scss'
})
export class ChatComponent implements OnInit, OnDestroy {
  chatService = inject(ChatService);
  private authService = inject(AuthService);
  private router = inject(Router);

  newMessage = '';
  currentUser = '';

  ngOnInit() {
    const user = this.authService.currentUser();
    if (!user) {
        this.currentUser = 'Yo'; 
    } else {
        this.currentUser = user.username;
    }

    const token = this.authService.token;
    if (!token) {
      this.router.navigate(['/login']);
      return;
    }

    this.chatService.startConnection(token);
  }

  sendMessage() {
    if (this.newMessage.trim()) {
      this.chatService.sendMessage(this.newMessage);
      this.newMessage = '';
    }
  }

  ngOnDestroy() {
    this.chatService.stopConnection();
  }
  
  logout() {
      this.authService.logout();
      this.router.navigate(['/login']);
  }
}
