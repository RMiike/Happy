import React from "react";
import mapMarkerImg from "../../assets/images/map-marker.svg";
import { FiPlus, FiArrowRight } from "react-icons/fi";
import { CreateOrphanage, PageMap, MapPopup } from "./styles";
import { MapContainer, TileLayer, Marker } from "react-leaflet";
import Leaflet from "leaflet";

import "leaflet/dist/leaflet.css";

const mapIcon = Leaflet.icon({
  iconUrl: mapMarkerImg,
  iconSize: [58, 68],
  iconAnchor: [29, 68],
  popupAnchor: [170, 2],
});
const OrphanagesMap: React.FC = () => {
  return (
    <PageMap>
      <aside>
        <header>
          <img src={mapMarkerImg} alt="Happy" />
          <h2>Escolha um orfanato no mapa.</h2>
          <p>Muitas crianças estão esperando a sua visita :)</p>
        </header>
        <footer>
          <strong>Brasília</strong>
          <span>Distrito Federal</span>
        </footer>
      </aside>
      <MapContainer
        center={[-15.8305799, -48.0383723]}
        zoom={15}
        style={{ width: "100%", height: "100%" }}
      >
        <TileLayer url="https://a.tile.openstreetmap.org/{z}/{x}/{y}.png" />
        <Marker icon={mapIcon} position={[-15.8305799, -48.0383723]}>
          <MapPopup>
            Lar das meninas
            <a href="">
              <FiArrowRight size={20} color="#FFF" />
            </a>
          </MapPopup>
        </Marker>
      </MapContainer>
      <CreateOrphanage to="">
        <FiPlus size={32} color="#fff" />
      </CreateOrphanage>
    </PageMap>
  );
};

export default OrphanagesMap;
