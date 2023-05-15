package anido.MSEproject;

import anido.MSEproject.controller.Validation;
import anido.MSEproject.domain.BoardOrigin;
import anido.MSEproject.domain.BoardBuffer;
import anido.MSEproject.repository.MemoryUserRepository;
import anido.MSEproject.repository.UserRepository;
import anido.MSEproject.service.BoardManager;
import anido.MSEproject.service.UserService;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;

@Configuration
public class SpringConfig {

    @Bean
    public UserService userService() {return new UserService(userRepository());}

    @Bean
    public UserRepository userRepository(){return new MemoryUserRepository();}

    @Bean
    public Validation validation() {return new Validation();}

    @Bean
    public BoardManager boardManager(){return new BoardManager( boardOrigin() , boardBuffer());}

    @Bean
    public BoardOrigin boardOrigin() {
        return new BoardOrigin();
    }

    @Bean
    public BoardBuffer boardBuffer(){
        return new BoardBuffer();
    }

}
