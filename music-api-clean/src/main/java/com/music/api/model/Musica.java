package com.music.api.model;

import jakarta.persistence.*;
import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.time.LocalDateTime;

@Entity
@Table(name = "musicas")
@Data
@NoArgsConstructor
@AllArgsConstructor
public class Musica {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;

    @Column(nullable = false, length = 200)
    private String titulo;

    @Column(nullable = false, length = 200)
    private String artista;

    @Column(length = 200)
    private String album;

    @Column(name = "ano_lancamento")
    private Integer anoLancamento;

    @Enumerated(EnumType.STRING)
    @Column(nullable = false, length = 50)
    private Genero genero;

    @Column(name = "duracao_segundos")
    private Integer duracaoSegundos;

    @Column(name = "data_cadastro", nullable = false, updatable = false)
    private LocalDateTime dataCadastro;

    @Column(name = "data_atualizacao")
    private LocalDateTime dataAtualizacao;

    @Column(columnDefinition = "TEXT")
    private String letra;

    @PrePersist
    protected void onCreate() {
        dataCadastro = LocalDateTime.now();
        dataAtualizacao = LocalDateTime.now();
    }

    @PreUpdate
    protected void onUpdate() {
        dataAtualizacao = LocalDateTime.now();
    }
}
