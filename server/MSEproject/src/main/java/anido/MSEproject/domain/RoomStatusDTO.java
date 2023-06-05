package anido.MSEproject.domain;


import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

@Getter
@Setter
@NoArgsConstructor
@AllArgsConstructor
public class RoomStatusDTO {
    private boolean isHost;
    private boolean isGameStarted;
    private String message;

}
