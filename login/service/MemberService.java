package hello.hellospring.service;

import hello.hellospring.domain.Member;
import hello.hellospring.repository.MemberRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.Optional;

/*
service class는 비즈니스에 가까운 용어를 써야한다.
비즈니스에 관한 서비스를 처리하기 때문에.
 */

@Service
public class MemberService {
    private final MemberRepository memberRepository;

    @Autowired //member service를 스프링이 생성을 할 때, 스프링 컨테이너에 있는 리포지토리를 넣어줌.
    public MemberService(MemberRepository memberRepository) {
        this.memberRepository = memberRepository;
    }

    //회원가입
    public Long join(Member member){
        //중복회원은 안됨.
        validateDuplicateMember(member); //중복회원 검증
        memberRepository.save(member);
        return member.getId();
    }

    private void validateDuplicateMember(Member member) {
        memberRepository.findByName(member.getName())
                .ifPresent(m -> {
                    throw new IllegalStateException("이미 존재하는 회원입니다.");
                });
    }
    
    //전체 회원 조회
    public List<Member> findMembers() {
            return memberRepository.findAll();
    }

    public Optional<Member> findOne(Long memberId){
        return memberRepository.findById(memberId);
    }
}
