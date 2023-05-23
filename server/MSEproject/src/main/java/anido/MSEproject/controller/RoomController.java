package anido.MSEproject.controller;

import anido.MSEproject.domain.User;
import lombok.RequiredArgsConstructor;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

@RestController
@RequiredArgsConstructor
@RequestMapping("/room")
public class RoomController {

    private User host;
    private User waitingPlayer;
    private boolean gameStarted;

    /**
     * API: Join Room
     * Description: Allows a player to join the room.
     * Method: POST
     * Endpoint: '/room/join1'
     * Input:
     *  {
     *   "id":1, // 얘는 나중에 JPA 적용하면 PK로 줄거라서 input에서 뺼거임
     *   "name": "testNAME1",
     *   "password": "123456",
     *   "win": 10,
     *   "lose": 5
     *  }
     * Output:
     *     - roomStatus: The status of the room after the player joins.
     */
    @PostMapping("/join1")
    public ResponseEntity<RoomStatus> joinRoom1(@RequestBody User user) {
        if (host == null) {
            host = user;
            return ResponseEntity.ok(new RoomStatus(true, false, "You are the host."));
        } else {
            return ResponseEntity.status(HttpStatus.BAD_REQUEST).body(new RoomStatus(false, false, "The room is already full."));
        }
    }

    /**
     * API: Join Room
     * Description: Allows a player to join the room.
     * Method: POST
     * Endpoint: '/room/join2'
     * Input:
     *  {
     *   "id":2, // 얘는 나중에 JPA 적용하면 PK로 줄거라서 input에서 뺼거임
     *   "name": "testNAME2",
     *   "password": "123456",
     *   "win": 10,
     *   "lose": 5
     *  }
     * Output:
     *     - roomStatus: The status of the room after the player joins.
     */
    @PostMapping("/join2")
    public ResponseEntity<RoomStatus> joinRoom2(@RequestBody User user) {
        if (waitingPlayer == null) {
            waitingPlayer = user;
            return ResponseEntity.ok(new RoomStatus(false, false, "Waiting for the host to start the game."));
        } else {
            return ResponseEntity.status(HttpStatus.BAD_REQUEST).body(new RoomStatus(false, false, "The room is already full."));
        }
    }

    /**
     * API: Start Game
     * Description: Starts the game if the host and a waiting player are present and the game start button is pressed.
     * Method: POST
     * Endpoint: '/room/start'
     * Input:
     *     - gameStartButtonPressed: Boolean indicating if the game start button was pressed.
     * Output:
     *  {
     *   "isHost": boolean,
     *   "isGameStarted": boolean,
     *   "message": String
     *  }
     */
    @PostMapping("/start")
    public ResponseEntity<RoomStatus> startGame(@RequestParam(required = false, defaultValue = "false") boolean gameStartButtonPressed) {
        if (host != null && waitingPlayer != null && !gameStarted) {
            if (gameStartButtonPressed) {
                gameStarted = true;
                return ResponseEntity.ok(new RoomStatus(true, true, "Game started!"));
            } else {
                return ResponseEntity.status(HttpStatus.BAD_REQUEST).body(new RoomStatus(false, false, "Cannot start the game."));
            }
        }

        return ResponseEntity.status(HttpStatus.BAD_REQUEST).body(new RoomStatus(false, false, "Unable to start the game."));
    }

    public class RoomStatus {
        private boolean isHost;
        private boolean isGameStarted;
        private String message;

        public RoomStatus(boolean isHost, boolean isGameStarted, String message) {
            this.isHost = isHost;
            this.isGameStarted = isGameStarted;
            this.message = message;
        }

        public boolean isHost() {
            return isHost;
        }

        public void setHost(boolean host) {
            isHost = host;
        }

        public boolean isGameStarted() {
            return isGameStarted;
        }

        public void setGameStarted(boolean gameStarted) {
            isGameStarted = gameStarted;
        }

        public String getMessage() {
            return message;
        }

        public void setMessage(String message) {
            this.message = message;
        }
    }
}
