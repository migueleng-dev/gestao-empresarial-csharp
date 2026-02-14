package com.anime.saas.model;

import jakarta.persistence.*;
import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.time.LocalDate;
import java.time.LocalDateTime;
import java.util.HashSet;
import java.util.Set;

@Entity
@Table(name = "animes")
@Data
@NoArgsConstructor
@AllArgsConstructor
public class Anime {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;

    @Column(nullable = false, length = 300)
    private String titulo;

    @Column(name = "titulo_ingles", length = 300)
    private String tituloIngles;

    @Column(name = "titulo_japones", length = 300)
    private String tituloJapones;

    @Column(columnDefinition = "TEXT")
    private String sinopse;

    @Enumerated(EnumType.STRING)
    @Column(nullable = false)
    private TipoAnime tipo;

    @Enumerated(EnumType.STRING)
    @Column(nullable = false)
    private StatusAnime status;

    @Column(name = "data_lancamento")
    private LocalDate dataLancamento;

    @Column(name = "data_finalizacao")
    private LocalDate dataFinalizacao;

    @Column(name = "numero_episodios")
    private Integer numeroEpisodios;

    @Column(name = "duracao_episodio")
    private Integer duracaoEpisodio;

    @Column(length = 100)
    private String estudio;

    @Column(length = 50)
    private String temporada;

    @ElementCollection
    @CollectionTable(name = "anime_generos", joinColumns = @JoinColumn(name = "anime_id"))
    @Column(name = "genero")
    @Enumerated(EnumType.STRING)
    private Set<GeneroAnime> generos = new HashSet<>();

    @Column(name = "url_poster", length = 500)
    private String urlPoster;

    @Column(name = "url_trailer", length = 500)
    private String urlTrailer;

    @Column(name = "nota_media")
    private Double notaMedia = 0.0;

    @Column(name = "total_avaliacoes")
    private Integer totalAvaliacoes = 0;

    @Column(name = "classificacao_etaria", length = 10)
    private String classificacaoEtaria;

    @Column(name = "premium_only")
    private Boolean premiumOnly = false;

    @Column(name = "data_cadastro", nullable = false, updatable = false)
    private LocalDateTime dataCadastro;

    @Column(name = "data_atualizacao")
    private LocalDateTime dataAtualizacao;

    @OneToMany(mappedBy = "anime", cascade = CascadeType.ALL)
    private Set<Episodio> episodios = new HashSet<>();

    @OneToMany(mappedBy = "anime", cascade = CascadeType.ALL)
    private Set<Avaliacao> avaliacoes = new HashSet<>();

    @PrePersist
    protected void onCreate() {
        dataCadastro = LocalDateTime.now();
        dataAtualizacao = LocalDateTime.now();
    }

    @PreUpdate
    protected void onUpdate() {
        dataAtualizacao = LocalDateTime.now();
    }

    public void calcularNotaMedia() {
        if (avaliacoes == null || avaliacoes.isEmpty()) {
            this.notaMedia = 0.0;
            this.totalAvaliacoes = 0;
            return;
        }
        
        double soma = avaliacoes.stream()
            .mapToDouble(Avaliacao::getNota)
            .sum();
        
        this.totalAvaliacoes = avaliacoes.size();
        this.notaMedia = soma / this.totalAvaliacoes;
    }
}
