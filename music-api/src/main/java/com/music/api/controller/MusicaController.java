package com.music.api.controller;

import com.music.api.dto.MusicaRequestDTO;
import com.music.api.dto.MusicaResponseDTO;
import com.music.api.model.Genero;
import com.music.api.service.MusicaService;
import io.swagger.v3.oas.annotations.Operation;
import io.swagger.v3.oas.annotations.Parameter;
import io.swagger.v3.oas.annotations.responses.ApiResponse;
import io.swagger.v3.oas.annotations.responses.ApiResponses;
import io.swagger.v3.oas.annotations.tags.Tag;
import jakarta.validation.Valid;
import lombok.RequiredArgsConstructor;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/api/musicas")
@RequiredArgsConstructor
@Tag(name = "Músicas", description = "API para gerenciamento de músicas")
public class MusicaController {

    private final MusicaService musicaService;

    @GetMapping
    @Operation(summary = "Listar todas as músicas", description = "Retorna uma lista com todas as músicas cadastradas")
    @ApiResponse(responseCode = "200", description = "Lista de músicas retornada com sucesso")
    public ResponseEntity<List<MusicaResponseDTO>> listarTodas() {
        List<MusicaResponseDTO> musicas = musicaService.listarTodas();
        return ResponseEntity.ok(musicas);
    }

    @GetMapping("/{id}")
    @Operation(summary = "Buscar música por ID", description = "Retorna uma música específica pelo seu ID")
    @ApiResponses(value = {
            @ApiResponse(responseCode = "200", description = "Música encontrada"),
            @ApiResponse(responseCode = "404", description = "Música não encontrada")
    })
    public ResponseEntity<MusicaResponseDTO> buscarPorId(
            @Parameter(description = "ID da música") @PathVariable Long id) {
        MusicaResponseDTO musica = musicaService.buscarPorId(id);
        return ResponseEntity.ok(musica);
    }

    @PostMapping
    @Operation(summary = "Criar nova música", description = "Cadastra uma nova música no sistema")
    @ApiResponses(value = {
            @ApiResponse(responseCode = "201", description = "Música criada com sucesso"),
            @ApiResponse(responseCode = "400", description = "Dados inválidos")
    })
    public ResponseEntity<MusicaResponseDTO> criar(@Valid @RequestBody MusicaRequestDTO requestDTO) {
        MusicaResponseDTO musica = musicaService.criar(requestDTO);
        return ResponseEntity.status(HttpStatus.CREATED).body(musica);
    }

    @PutMapping("/{id}")
    @Operation(summary = "Atualizar música", description = "Atualiza os dados de uma música existente")
    @ApiResponses(value = {
            @ApiResponse(responseCode = "200", description = "Música atualizada com sucesso"),
            @ApiResponse(responseCode = "404", description = "Música não encontrada"),
            @ApiResponse(responseCode = "400", description = "Dados inválidos")
    })
    public ResponseEntity<MusicaResponseDTO> atualizar(
            @Parameter(description = "ID da música") @PathVariable Long id,
            @Valid @RequestBody MusicaRequestDTO requestDTO) {
        MusicaResponseDTO musica = musicaService.atualizar(id, requestDTO);
        return ResponseEntity.ok(musica);
    }

    @DeleteMapping("/{id}")
    @Operation(summary = "Deletar música", description = "Remove uma música do sistema")
    @ApiResponses(value = {
            @ApiResponse(responseCode = "204", description = "Música deletada com sucesso"),
            @ApiResponse(responseCode = "404", description = "Música não encontrada")
    })
    public ResponseEntity<Void> deletar(@Parameter(description = "ID da música") @PathVariable Long id) {
        musicaService.deletar(id);
        return ResponseEntity.noContent().build();
    }

    @GetMapping("/artista/{artista}")
    @Operation(summary = "Buscar músicas por artista", description = "Retorna todas as músicas de um artista específico")
    @ApiResponse(responseCode = "200", description = "Lista de músicas retornada com sucesso")
    public ResponseEntity<List<MusicaResponseDTO>> buscarPorArtista(
            @Parameter(description = "Nome do artista") @PathVariable String artista) {
        List<MusicaResponseDTO> musicas = musicaService.buscarPorArtista(artista);
        return ResponseEntity.ok(musicas);
    }

    @GetMapping("/genero/{genero}")
    @Operation(summary = "Buscar músicas por gênero", description = "Retorna todas as músicas de um gênero específico")
    @ApiResponse(responseCode = "200", description = "Lista de músicas retornada com sucesso")
    public ResponseEntity<List<MusicaResponseDTO>> buscarPorGenero(
            @Parameter(description = "Gênero musical") @PathVariable Genero genero) {
        List<MusicaResponseDTO> musicas = musicaService.buscarPorGenero(genero);
        return ResponseEntity.ok(musicas);
    }

    @GetMapping("/album/{album}")
    @Operation(summary = "Buscar músicas por álbum", description = "Retorna todas as músicas de um álbum específico")
    @ApiResponse(responseCode = "200", description = "Lista de músicas retornada com sucesso")
    public ResponseEntity<List<MusicaResponseDTO>> buscarPorAlbum(
            @Parameter(description = "Nome do álbum") @PathVariable String album) {
        List<MusicaResponseDTO> musicas = musicaService.buscarPorAlbum(album);
        return ResponseEntity.ok(musicas);
    }

    @GetMapping("/ano/{ano}")
    @Operation(summary = "Buscar músicas por ano", description = "Retorna todas as músicas de um ano específico")
    @ApiResponse(responseCode = "200", description = "Lista de músicas retornada com sucesso")
    public ResponseEntity<List<MusicaResponseDTO>> buscarPorAno(
            @Parameter(description = "Ano de lançamento") @PathVariable Integer ano) {
        List<MusicaResponseDTO> musicas = musicaService.buscarPorAno(ano);
        return ResponseEntity.ok(musicas);
    }

    @GetMapping("/buscar")
    @Operation(summary = "Buscar músicas por termo", description = "Busca músicas por título, artista ou álbum")
    @ApiResponse(responseCode = "200", description = "Lista de músicas retornada com sucesso")
    public ResponseEntity<List<MusicaResponseDTO>> buscarPorTermo(
            @Parameter(description = "Termo de busca") @RequestParam String termo) {
        List<MusicaResponseDTO> musicas = musicaService.buscarPorTermo(termo);
        return ResponseEntity.ok(musicas);
    }

    @GetMapping("/periodo")
    @Operation(summary = "Buscar músicas por período", description = "Retorna músicas lançadas em um período específico")
    @ApiResponse(responseCode = "200", description = "Lista de músicas retornada com sucesso")
    public ResponseEntity<List<MusicaResponseDTO>> buscarPorPeriodo(
            @Parameter(description = "Ano inicial") @RequestParam Integer anoInicio,
            @Parameter(description = "Ano final") @RequestParam Integer anoFim) {
        List<MusicaResponseDTO> musicas = musicaService.buscarPorPeriodo(anoInicio, anoFim);
        return ResponseEntity.ok(musicas);
    }
}
