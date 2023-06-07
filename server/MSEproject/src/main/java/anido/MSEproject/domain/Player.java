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
@Table(name="player_table")
//@Embeddable
public class Player extends User{

    @Column(name="player_action")
    private String action; //moving, blocking

    @Column(name="cur_row")
    private int row; //현재위치?

    @Column(name="cur_col")
    private int col; //현재위치

    public Player(User user, int row, int col){
        setName(user.getName());
        setId(user.getId());
        this.row = row;
        this.col = col;
    }

}
