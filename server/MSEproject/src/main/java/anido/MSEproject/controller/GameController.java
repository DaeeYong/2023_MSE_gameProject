package anido.MSEproject.controller;

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
    private final Player player1;
    private final Player player2;

    @Autowired
    public GameController(GameService gameService,Player player1, Player player2) {
        this.gameService = gameService;
        this.player1 = new Player(player1, 0, 0, false);
        this.player2 = new Player(player2, 0, 0, false);
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

    @GetMapping("/current/player2")
    public ResponseEntity<?> fetchLocationPlayer2() {
        int x = player2.getxNow();
        int y = player2.getyNow();
        return ResponseEntity.ok().body("{x: " + x + ", y: " + y + "}");
    }
}
