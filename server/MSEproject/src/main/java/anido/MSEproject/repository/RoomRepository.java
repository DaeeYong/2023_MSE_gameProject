package anido.MSEproject.repository;

import anido.MSEproject.domain.RoomStatusDTO;
import org.springframework.data.jpa.repository.JpaRepository;

public interface RoomRepository extends JpaRepository<RoomStatusDTO,Long> {
}
