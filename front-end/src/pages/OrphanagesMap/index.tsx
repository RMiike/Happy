import React, { useEffect, useState } from "react";
import api from "../../services/api";
import mapMarkerImg from "../../assets/images/map-marker.svg";
import { Link } from "react-router-dom";
import { FiPlus, FiArrowRight } from "react-icons/fi";
import {
  CreateOrphanage,
  PageMap,
  MapPopup,
  Map,
  MapTileLayer,
  MapMarker,
} from "./styles";

import "leaflet/dist/leaflet.css";

interface IOrphanage {
  id: string;
  name: string;
  latitude: number;
  longitude: number;
}

const OrphanagesMap: React.FC = () => {
  const [orphanages, setOrphanages] = useState<IOrphanage[]>([]);
  useEffect(() => {
    api.get("orphanages").then((response) => {
      setOrphanages(response.data);
    });
  }, []);
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
      <Map>
        <MapTileLayer />
        {orphanages.map((orphanage) => {
          return (
            <MapMarker
              key={orphanage.id}
              position={[orphanage.latitude, orphanage.longitude]}
            >
              <MapPopup>
                {orphanage.name}
                <Link to={`orphanages/${orphanage.id}`}>
                  <FiArrowRight size={20} color="#FFF" />
                </Link>
              </MapPopup>
            </MapMarker>
          );
        })}
      </Map>
      <CreateOrphanage to="orphanages/create">
        <FiPlus size={32} color="#fff" />
      </CreateOrphanage>
    </PageMap>
  );
};

export default OrphanagesMap;
