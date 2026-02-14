package com.music.api.dto;

import com.music.api.model.Genero;
import jakarta.validation.constraints.*;
import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

@Data
@NoArgsConstructor
@AllArgsConstructor
public class MusicaRequestDTO {

    @NotBlank(message = "Título é obrigatório")
    @Size(min = 1, max = 200, message = "Título deve ter entre 1 e 200 caracteres")
    private String titulo;

    @NotBlank(message = "Artista é obrigatório")
    @Size(min = 1, max = 200, message = "Artista deve ter entre 1 e 200 caracteres")
    private String artista;

    @Size(max = 200, message = "Álbum deve ter no máximo 200 caracteres")
    private String album;

    @Min(value = 1900, message = "Ano de lançamento deve ser maior ou igual a 1900")
    @Max(value = 2100, message = "Ano de lançamento deve ser menor ou igual a 2100")
    private Integer anoLancamento;

    @NotNull(message = "Gênero é obrigatório")
    private Genero genero;

    @Min(value = 1, message = "Duração deve ser maior que 0 segundos")
    @Max(value = 7200, message = "Duração deve ser menor que 7200 segundos (2 horas)")
    private Integer duracaoSegundos;

    private String letra;
}
