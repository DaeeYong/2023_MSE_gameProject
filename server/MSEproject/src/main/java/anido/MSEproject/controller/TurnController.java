package anido.MSEproject.domain;

import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController
@RequestMapping("/turn") // URL : localhost:8080/turn/game/...
public class TurnController {
	
private final TurnService turnService;
	
    public TurnController(TurnService turnService) {
        this.turnService = turnService;
    }
	
    @GetMapping("/game/currentPlayer")
    public Player getCurrentPlayer() {
        return turnService.getCurrentPlayer();
    }
    
    @GetMapping("/game/previousCoordinate")
    public Coordinate getPreviousCoordinate() {
        return turnService.getPreviousCoordinate();
    }
    
    @PostMapping("/game/coordinate")
    public void setCoordinate(@RequestBody Coordinate coordinate) {
        turnService.setCoordinate(coordinate);
    }
    
    @GetMapping("/game/player/{playerId}")
    public Player getPlayerById(@PathVariable String playerId) {
        return turnService.getPlayerById(playerId);
    }
    
    @PostMapping("/game/player/{playerId}/turnEnd")
    public void endTurn(@PathVariable String playerId) {
        turnService.endTurn(playerId);
    }
	
}
