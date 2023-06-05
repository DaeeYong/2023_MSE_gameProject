package anido.MSEproject.controller;

import anido.MSEproject.domain.RoomStatusDTO;
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
     *      "id":1, // 얘는 나중에 JPA 적용하면 PK로 줄거라서 input에서 뺼거임
     *      "name": "testNAME1",
     *      "password": "123456",
     *      "win": 10,
     *      "lose": 5
     *  }
     * Output:
     *     - roomStatus: The status of the room after the player joins.
     */
    @PostMapping("/join1")
    public ResponseEntity<RoomStatusDTO> joinRoom1(@RequestBody User user) {
        RoomStatusDTO roomStatusDTO = new RoomStatusDTO();
        if (host == null) {
            host = user;
            roomStatusDTO.setHost(true);
            roomStatusDTO.setGameStarted(false);
            roomStatusDTO.setMessage("You are the host");
            return ResponseEntity.ok(roomStatusDTO);
            // return ResponseEntity.ok(new RoomStatusDTO(true, false, "You are the host."));
        } else {
            roomStatusDTO.setHost(false);
            roomStatusDTO.setGameStarted(false);
            roomStatusDTO.setMessage("The room is already full.");
            return ResponseEntity.status(HttpStatus.BAD_REQUEST).body(roomStatusDTO);
            // return ResponseEntity.status(HttpStatus.BAD_REQUEST).body(new RoomStatusDTO(false, false, "The room is already full."));
        }
    }

    /**
     * API: Join Room
     * Description: Allows a player to join the room.
     * Method: POST
     * Endpoint: '/room/join2'
     * Input:
     *  {
     *      "id":2, // 얘는 나중에 JPA 적용하면 PK로 줄거라서 input에서 뺼거임
     *      "name": "testNAME2",
     *      "password": "123456",
     *      "win": 10,
     *      "lose": 5
     *  }
     * Output:
     *     - roomStatus: The status of the room after the player joins.
     */
    @PostMapping("/join2")
    public ResponseEntity<RoomStatusDTO> joinRoom2(@RequestBody User user) {
        RoomStatusDTO roomStatusDTO = new RoomStatusDTO();
        if (waitingPlayer == null) {
            waitingPlayer = user;
            roomStatusDTO.setHost(false);
            roomStatusDTO.setGameStarted(false);
            roomStatusDTO.setMessage("Waiting for the host to start the game.");
            return ResponseEntity.ok(roomStatusDTO);
           // return ResponseEntity.ok(new RoomStatusDTO(false, false, "Waiting for the host to start the game."));
        } else {
            roomStatusDTO.setHost(false);
            roomStatusDTO.setGameStarted(false);
            roomStatusDTO.setMessage("The room is already full.");
            return ResponseEntity.status(HttpStatus.BAD_REQUEST).body(roomStatusDTO);
            // return ResponseEntity.status(HttpStatus.BAD_REQUEST).body(new RoomStatusDTO(false, false, "The room is already full."));
        }
    }

    /**
     * API: Start Game
     * Description: Starts the game if the host and a waiting player are present and the game start button is pressed.
     * Method: POST
     * Endpoint: '/room/start'
     * Input:
     *     - gameStartButtonPressed: Boolean indicating if the game start button was pressed.
     *
     *     client -> localhost:8080/room/start?button=value
     *
     * Output:
     *  {
     *      "isHost": boolean,
     *      "isGameStarted": boolean,
     *      "message": String,
     *  }
     */
    @GetMapping("/start")
    public ResponseEntity<RoomStatusDTO> startGame(@RequestParam(required = true, name="button") boolean button) {
        RoomStatusDTO roomStatusDTO = new RoomStatusDTO();
        if (host != null && waitingPlayer != null && !gameStarted) {
            if (button) {
                gameStarted = true;
                roomStatusDTO.setGameStarted(true);
                roomStatusDTO.setHost(true);
                roomStatusDTO.setMessage("Game started!");
                return ResponseEntity.ok(roomStatusDTO);
                // return ResponseEntity.ok(new RoomStatusDTO(true, true, "Game started!"));
            } else {
                roomStatusDTO.setGameStarted(false);
                roomStatusDTO.setHost(false);
                roomStatusDTO.setMessage("Cannot start the game.");
                return ResponseEntity.status(HttpStatus.BAD_REQUEST).body(roomStatusDTO);
                // return ResponseEntity.status(HttpStatus.BAD_REQUEST).body(new RoomStatusDTO(false, false, "Cannot start the game."));
            }
        }
        roomStatusDTO.setGameStarted(false);
        roomStatusDTO.setHost(false);
        roomStatusDTO.setMessage("Unable to start the game.");
        return ResponseEntity.status(HttpStatus.BAD_REQUEST).body(roomStatusDTO);
    }
}
