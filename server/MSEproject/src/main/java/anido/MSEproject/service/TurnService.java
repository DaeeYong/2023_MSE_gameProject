package anido.MSEproject.service;

import org.springframework.stereotype.Service;

@Service
public class TurnService {
	
    private Player currentPlayer;
    private Coordinate previousCoordinate;
    private final Player player1 = new Player("1", "Player 1", true);
    private final Player player2 = new Player("2", "Player 2", false);
    
    public Player getCurrentPlayer() {
        return currentPlayer;
    }
    
    public Coordinate getPreviousCoordinate() {
        return previousCoordinate;
    }
    
    public void setCoordinate(Coordinate coordinate) {
        if (currentPlayer == null) {
            currentPlayer = player1;
        } else { // p1이면 p2로, p2면 p1로 턴 전환
            currentPlayer = currentPlayer == player1 ? player2 : player1;
        }
        if (isValidObstacle(coordinate)) { // 좌표에 놓을 수 있는 경우에만 좌표 변경하고 턴 전환
            previousCoordinate = coordinate;
            currentPlayer.setMyTurn(true);
        } else {
            throw new RuntimeException("Invalid coordinate");
        }
    }
    
    // temp method
    public boolean isValidObstacle(Coordinate coordinate) {
    	return true;
    }
    // 임시메소드. 
    // 리퀘스트로 받은 좌표값으로 알고리즘을 수행하고, 그 알고리즘을 여기서 어떻게
    // 불러와서 써야하는지 고민중
    
    public Player getPlayerById(String playerId) {
        if (player1.getId().equals(playerId)) {
            return player1;
        } else if (player2.getId().equals(playerId)) {
            return player2;
        } else {
            throw new RuntimeException("Invalid player ID");
        }
    }
    
    public void endTurn(String playerId) {
        if (player1.getId().equals(playerId)) {
            player1.setMyTurn(false);
        } else if (player2.getId().equals(playerId)) {
            player2.setMyTurn(false);
        } else {
            throw new RuntimeException("Invalid player ID");
        }
    }
	
}
