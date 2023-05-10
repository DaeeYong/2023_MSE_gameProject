package anido.MSEproject.domain;

public abstract class Board {
    private int[][] board = new int[17][17];

    public int[][] getBoard() {
        return board;
    }

    public void clearBoard(){
        for(int i=0; i< board.length; i++){
            for(int j=0; j<board.length; j++){
                board[i][j] = 0;
            }
        }
    }

    public void setBoardValue(int x, int y, int value){
        board[x][y] = value;
    }

    public int getBoardValue(int x, int y){
        return board[x][y];
    }

}
