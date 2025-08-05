# UsersService

This service is responsible for managing users and their subscriptions.  
It provides REST API endpoints for CRUD operations and user filtering by subscription type.

## Build Docker Image
```bash
  docker build -t users_service:test -f UsersService/Dockerfile .