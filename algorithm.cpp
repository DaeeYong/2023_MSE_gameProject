//알고리즘 수도코드
#include<bits/stdc++.h>
using namespace std;

#define X first
#define Y second

int board[17][17];
int visited[17][17];
int dx[4] = { -1,0,1,0 };
int dy[4] = { 0,1,0,-1 };

int main() {
	ios::sync_with_stdio(0);
	cin.tie(0);
  
  while (!Q.empty()) {
    auto cur = Q.front(); Q.pop();
    for (int dir = 0; dir < 4; dir++) {
      int nx = cur.X + dx[dir];
      int ny = cur.Y + dy[dir];
      if (nx < 0 || nx >= n || ny < 0 || ny >= m) continue;
      if (board[nx][ny] != 1 || visited[nx][ny] != 0) continue;
      visited[nx][ny] = 1;
      Q.push({ nx,ny });
	}
	return 0;
}
