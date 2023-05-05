package hello.hellospring.repository;

import hello.hellospring.domain.Member;

import java.util.List;
import java.util.Optional;

public interface MemberRepository {
    Member save(Member member);
    Optional<Member> findById(Long id); //Null을 처리하는 방법. Null일 경우, Optional로 감싸서 가져옴.
    Optional<Member> findByName(String name);
    List<Member> findAll(); //모든 회원 리스트를 반환
}
