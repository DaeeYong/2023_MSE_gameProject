package anido.MSEproject;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.boot.autoconfigure.jdbc.DataSourceAutoConfiguration;

@SpringBootApplication(exclude={DataSourceAutoConfiguration.class}) // db사용 안하겠다는 뜻. db구축 후에 삭제예정
public class MsEprojectApplication {

	public static void main(String[] args) {
		SpringApplication.run(MsEprojectApplication.class, args);
	}

}
