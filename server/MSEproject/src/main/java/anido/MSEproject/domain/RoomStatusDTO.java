
package anido.MSEproject.domain;


import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

import javax.persistence.*;


@Entity
@Getter
@Setter
@NoArgsConstructor
@AllArgsConstructor
@Table(name="roomstatus_table")
public class RoomStatusDTO {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;

   // @Embedded
   // private User host;
   // @Embedded
   // private User waitingPlayer;

    private boolean hostReady;
    private boolean waitingPlayerReady;

    private boolean isHostCheck;
    private boolean isGameStarted;

    private String message;

}
