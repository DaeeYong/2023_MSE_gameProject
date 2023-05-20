package anido.MSEproject.controller;

import anido.MSEproject.domain.User;
import anido.MSEproject.service.UserService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RestController;

import anido.MSEproject.domain.Player;
import anido.MSEproject.service.GameService;

@RestController
@RequestMapping("/location")
public class GameController {
    private final GameService gameService;
    private final UserService userService;

    @Autowired
    public GameController(GameService gameService, UserService userService) {
        this.gameService = gameService;
        this.userService = userService;
    }

    @GetMapping("/update/player1")
    public ResponseEntity<?> updateLocationPlayer1(@RequestParam int x, @RequestParam int y) {
        gameService.updatePlayerCoordinate(player1, x, y);
        return ResponseEntity.ok().body("{valid: true}");
      //return new ResponseEntity<>(player1,HttpStatus.OK);
    }

    @GetMapping("/update/player2")
    public ResponseEntity<?> updateLocationPlayer2(@RequestParam int x, @RequestParam int y) {
        gameService.updatePlayerCoordinate(player2, x, y);
        return ResponseEntity.ok().body("{valid: true}");
        //return new ResponseEntity<>(player2,HttpStatus.OK);
    }

    @GetMapping("/current/player1")
    public ResponseEntity<?> fetchLocationPlayer1() {
        int x = player1.getxNow();
        int y = player1.getyNow();
        return ResponseEntity.ok().body("{x: " + x + ", y: " + y + "}");
    }

    //test
    @GetMapping("/current/player2")
    public ResponseEntity<?> fetchLocationPlayer2() {
        int x = player2.getxNow();
        int y = player2.getyNow();
        return ResponseEntity.ok().body("{x: " + x + ", y: " + y + "}");
    }
}
