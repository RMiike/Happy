import React, { useState, ChangeEvent } from "react";
import { FiPlus } from "react-icons/fi";
import { useHistory } from "react-router-dom";
import { useMapEvents } from "react-leaflet";
import api from "../../services/api";
import Sidebar from "../../components/Sidebar";
import {
  PageCreateOrphanage,
  MapMarker,
  Map,
  MapTileLayer,
  CreateOrphanageForm,
  InputBlock,
  ImageContainer,
  NewImage,
  ButtonSelect,
  ConfirmButton,
} from "./styles";
import { FormEvent } from "react";

const CreateOrphanage: React.FC = () => {
  const history = useHistory();
  const [name, setName] = useState("");
  const [about, setAbout] = useState("");
  const [instructions, setInstructions] = useState("");
  const [openingHours, setOpeningHours] = useState("");
  const [openOnWeekends, setOpenOnWeekends] = useState(true);
  const [images, setImages] = useState<File[]>([]);
  const [previewImages, setPreviewImages] = useState<string[]>([]);
  const [position, setPosition] = useState({
    latitude: 1,
    longitude: 1,
  });
  function LocationMarker() {
    const map = useMapEvents({
      click(e) {
        setPosition({ latitude: e.latlng.lat, longitude: e.latlng.lng });
        map.flyTo(e.latlng, map.getZoom());
      },
    });
    return position.latitude === 1 ? null : (
      <MapMarker position={[position.latitude, position.longitude]} />
    );
  }
  async function handleSubmit(event: FormEvent) {
    event.preventDefault();
    const { latitude, longitude } = position;

    const data = new FormData();
    data.append("name", name);
    data.append("about", about);
    data.append("instructions", instructions);
    data.append("openingHours", openingHours);
    data.append("latitude", String(latitude).replace(".", ","));
    data.append("longitude", String(longitude).replace(".", ","));
    data.append("openOnWeekends", String(openOnWeekends));
    images.forEach((image) => {
      data.append("images", image);
    });
    var response = await api.post("orphanages", data);
    console.log(response);
    alert("cadastro realizado com sucesso.");
    history.push("/app");
  }
  function handleSelectImages(event: ChangeEvent<HTMLInputElement>) {
    if (!event.target.files) {
      return;
    }
    const selectedImages = Array.from(event.target.files);
    setImages(selectedImages);
    const selectedImagesPreview = selectedImages.map((image) => {
      return URL.createObjectURL(image);
    });
    setPreviewImages(selectedImagesPreview);
  }
  return (
    <PageCreateOrphanage>
      <Sidebar />
      <main>
        <CreateOrphanageForm onSubmit={handleSubmit}>
          <fieldset>
            <legend>Dados</legend>
            <Map center={[-15.8305799, -48.0383723]}>
              <MapTileLayer />
              <LocationMarker />
            </Map>
            <InputBlock>
              <label htmlFor="name">Nome</label>
              <input
                type="text"
                id="name"
                value={name}
                onChange={(e) => setName(e.target.value)}
              />
            </InputBlock>
            <InputBlock>
              <label htmlFor="name">
                Sobre <span> Máximo de 250 caracteres.</span>
              </label>
              <textarea
                id="about"
                maxLength={250}
                value={about}
                onChange={(e) => setAbout(e.target.value)}
              />
            </InputBlock>
            <InputBlock>
              <label htmlFor="images">Fotos</label>
              <ImageContainer>
                {previewImages.map((image) => {
                  return <img key={image} src={image} alt={name} />;
                })}
                <NewImage htmlFor="image[]">
                  <FiPlus size={24} color="#15b6d6" />
                </NewImage>
              </ImageContainer>
              <input
                multiple
                onChange={handleSelectImages}
                type="file"
                id="image[]"
              />
            </InputBlock>
          </fieldset>
          <fieldset>
            <legend>Visitação</legend>
            <InputBlock>
              <label htmlFor="instructions">Instruções</label>
              <textarea
                id="instructions"
                value={instructions}
                onChange={(e) => setInstructions(e.target.value)}
              />
            </InputBlock>
            <InputBlock>
              <label htmlFor="openingHours">Horário de funcionamento</label>
              <input
                id="openingHours"
                value={openingHours}
                onChange={(e) => setOpeningHours(e.target.value)}
              />
            </InputBlock>
            <InputBlock>
              <label htmlFor="openOnWeekends">Atende fim de semana</label>
              <ButtonSelect>
                <button
                  type="button"
                  className={openOnWeekends ? "active" : ""}
                  onClick={() => setOpenOnWeekends(true)}
                >
                  Sim
                </button>
                <button
                  type="button"
                  className={!openOnWeekends ? "active" : ""}
                  onClick={() => setOpenOnWeekends(false)}
                >
                  Não
                </button>
              </ButtonSelect>
            </InputBlock>
          </fieldset>
          <ConfirmButton type="submit">Confirmar</ConfirmButton>
        </CreateOrphanageForm>
      </main>
    </PageCreateOrphanage>
  );
};

export default CreateOrphanage;
