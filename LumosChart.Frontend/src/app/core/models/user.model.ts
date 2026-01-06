export interface User {
    id: string;
    username: string;
    avatarUrl: string;
    token?: string;
}

export interface LoginResponse {
    token: string;
}
