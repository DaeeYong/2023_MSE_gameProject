#include<iostream>
#include<utility>
#include<queue>

using namespace std;

#define X first
#define Y second
#define BORD_SIZE 17

#define VISITED 1
#define PLAYER1 2
#define PLAYER2 3
#define BLOCK 4

int dx[4] = { -1,0,1,0 };
int dy[4] = { 0,1,0,-1 };

int board[17][17];
int visited[17][17];

//벽->1, p1->2, p2 -> 3

int isValid(pair<int, int> Coord, int playerType);
int main() {
    ios::sync_with_stdio(0);
    cin.tie(0);

    return 0;
}

int isValid(pair<int, int> Coord, int playerType) {
    
    for (int i = 0; i < BORD_SIZE; i++) {
        for (int j = 0; j < BORD_SIZE; j++) {
            visited[i][j] = 0;
        }
    }

    for (int i = 0; i < BORD_SIZE; i++) {
        for (int j = 0; j < BORD_SIZE; j++) {
            visited[i][j] = board[i][j];
        }
    }
    queue <pair<int, int>> Q;
    
    Q.push(Coord);
    while (!Q.empty())
    {
        auto cur = Q.front(); Q.pop();
        for (int direction = 0; direction < 4; direction++) {
            int nx = dx[direction] + cur.X;
            int ny = dy[direction] + cur.Y;
            
            if (nx < 0 || nx >= BORD_SIZE || ny < 0 || ny >= BORD_SIZE) continue;
            if (board[nx][ny] == 1 || visited[nx][ny] == VISITED) continue;
            visited[nx][ny] = VISITED;
            Q.push({ nx,ny });
        }
    }
}
