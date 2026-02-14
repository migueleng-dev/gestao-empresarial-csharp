package com.music.api.service;

import com.music.api.dto.MusicaRequestDTO;
import com.music.api.dto.MusicaResponseDTO;
import com.music.api.exception.ResourceNotFoundException;
import com.music.api.model.Genero;
import com.music.api.model.Musica;
import com.music.api.repository.MusicaRepository;
import lombok.RequiredArgsConstructor;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import java.util.List;
import java.util.stream.Collectors;

@Service
@RequiredArgsConstructor
public class MusicaService {

    private final MusicaRepository musicaRepository;

    @Transactional(readOnly = true)
    public List<MusicaResponseDTO> listarTodas() {
        return musicaRepository.findAll()
                .stream()
                .map(this::convertToDTO)
                .collect(Collectors.toList());
    }

    @Transactional(readOnly = true)
    public MusicaResponseDTO buscarPorId(Long id) {
        Musica musica = musicaRepository.findById(id)
                .orElseThrow(() -> new ResourceNotFoundException("Música não encontrada com id: " + id));
        return convertToDTO(musica);
    }

    @Transactional
    public MusicaResponseDTO criar(MusicaRequestDTO requestDTO) {
        Musica musica = convertToEntity(requestDTO);
        Musica musicaSalva = musicaRepository.save(musica);
        return convertToDTO(musicaSalva);
    }

    @Transactional
    public MusicaResponseDTO atualizar(Long id, MusicaRequestDTO requestDTO) {
        Musica musica = musicaRepository.findById(id)
                .orElseThrow(() -> new ResourceNotFoundException("Música não encontrada com id: " + id));

        musica.setTitulo(requestDTO.getTitulo());
        musica.setArtista(requestDTO.getArtista());
        musica.setAlbum(requestDTO.getAlbum());
        musica.setAnoLancamento(requestDTO.getAnoLancamento());
        musica.setGenero(requestDTO.getGenero());
        musica.setDuracaoSegundos(requestDTO.getDuracaoSegundos());
        musica.setLetra(requestDTO.getLetra());

        Musica musicaAtualizada = musicaRepository.save(musica);
        return convertToDTO(musicaAtualizada);
    }

    @Transactional
    public void deletar(Long id) {
        if (!musicaRepository.existsById(id)) {
            throw new ResourceNotFoundException("Música não encontrada com id: " + id);
        }
        musicaRepository.deleteById(id);
    }

    @Transactional(readOnly = true)
    public List<MusicaResponseDTO> buscarPorArtista(String artista) {
        return musicaRepository.findByArtista(artista)
                .stream()
                .map(this::convertToDTO)
                .collect(Collectors.toList());
    }

    @Transactional(readOnly = true)
    public List<MusicaResponseDTO> buscarPorGenero(Genero genero) {
        return musicaRepository.findByGenero(genero)
                .stream()
                .map(this::convertToDTO)
                .collect(Collectors.toList());
    }

    @Transactional(readOnly = true)
    public List<MusicaResponseDTO> buscarPorAlbum(String album) {
        return musicaRepository.findByAlbum(album)
                .stream()
                .map(this::convertToDTO)
                .collect(Collectors.toList());
    }

    @Transactional(readOnly = true)
    public List<MusicaResponseDTO> buscarPorAno(Integer ano) {
        return musicaRepository.findByAnoLancamento(ano)
                .stream()
                .map(this::convertToDTO)
                .collect(Collectors.toList());
    }

    @Transactional(readOnly = true)
    public List<MusicaResponseDTO> buscarPorTermo(String termo) {
        return musicaRepository.buscarPorTermo(termo)
                .stream()
                .map(this::convertToDTO)
                .collect(Collectors.toList());
    }

    @Transactional(readOnly = true)
    public List<MusicaResponseDTO> buscarPorPeriodo(Integer anoInicio, Integer anoFim) {
        return musicaRepository.buscarPorPeriodo(anoInicio, anoFim)
                .stream()
                .map(this::convertToDTO)
                .collect(Collectors.toList());
    }

    private MusicaResponseDTO convertToDTO(Musica musica) {
        MusicaResponseDTO dto = new MusicaResponseDTO();
        dto.setId(musica.getId());
        dto.setTitulo(musica.getTitulo());
        dto.setArtista(musica.getArtista());
        dto.setAlbum(musica.getAlbum());
        dto.setAnoLancamento(musica.getAnoLancamento());
        dto.setGenero(musica.getGenero());
        dto.setDuracaoSegundos(musica.getDuracaoSegundos());
        dto.setDataCadastro(musica.getDataCadastro());
        dto.setDataAtualizacao(musica.getDataAtualizacao());
        dto.setLetra(musica.getLetra());
        return dto;
    }

    private Musica convertToEntity(MusicaRequestDTO dto) {
        Musica musica = new Musica();
        musica.setTitulo(dto.getTitulo());
        musica.setArtista(dto.getArtista());
        musica.setAlbum(dto.getAlbum());
        musica.setAnoLancamento(dto.getAnoLancamento());
        musica.setGenero(dto.getGenero());
        musica.setDuracaoSegundos(dto.getDuracaoSegundos());
        musica.setLetra(dto.getLetra());
        return musica;
    }
}
