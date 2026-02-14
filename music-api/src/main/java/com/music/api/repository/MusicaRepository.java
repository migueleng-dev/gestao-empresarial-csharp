package com.music.api.repository;

import com.music.api.model.Genero;
import com.music.api.model.Musica;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import java.util.List;

@Repository
public interface MusicaRepository extends JpaRepository<Musica, Long> {

    List<Musica> findByArtista(String artista);

    List<Musica> findByGenero(Genero genero);

    List<Musica> findByAlbum(String album);

    List<Musica> findByAnoLancamento(Integer anoLancamento);

    @Query("SELECT m FROM Musica m WHERE LOWER(m.titulo) LIKE LOWER(CONCAT('%', :termo, '%')) " +
           "OR LOWER(m.artista) LIKE LOWER(CONCAT('%', :termo, '%')) " +
           "OR LOWER(m.album) LIKE LOWER(CONCAT('%', :termo, '%'))")
    List<Musica> buscarPorTermo(@Param("termo") String termo);

    @Query("SELECT m FROM Musica m WHERE m.anoLancamento BETWEEN :anoInicio AND :anoFim")
    List<Musica> buscarPorPeriodo(@Param("anoInicio") Integer anoInicio, @Param("anoFim") Integer anoFim);
}
