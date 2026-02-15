package com.music.api.dto;

import com.music.api.model.Genero;
import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.time.LocalDateTime;

@Data
@NoArgsConstructor
@AllArgsConstructor
public class MusicaResponseDTO {

    private Long id;
    private String titulo;
    private String artista;
    private String album;
    private Integer anoLancamento;
    private Genero genero;
    private Integer duracaoSegundos;
    private String duracaoFormatada;
    private LocalDateTime dataCadastro;
    private LocalDateTime dataAtualizacao;
    private String letra;

    public String getDuracaoFormatada() {
        if (duracaoSegundos == null) {
            return "00:00";
        }
        int minutos = duracaoSegundos / 60;
        int segundos = duracaoSegundos % 60;
        return String.format("%02d:%02d", minutos, segundos);
    }
}
