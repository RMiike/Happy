import React, { useEffect, useState } from "react";
import api from "../../services/api";
import { FaWhatsapp } from "react-icons/fa";
import { FiClock, FiInfo } from "react-icons/fi";
import Sidebar from "../../components/Sidebar";
import { useParams } from "react-router-dom";
import {
  PageOrphanage,
  OrphanageDetails,
  Images,
  OrphanageDetailsContent,
  MapMarker,
  Map,
  MapContainerDiv,
  MapTileLayer,
  OpenDetails,
  Hour,
  OpenOnWeekends,
  ContactButton,
} from "./styles";

interface IOrphanage {
  name: string;
  latitude: number;
  longitude: number;
  about: string;
  instructions: string;
  openingHours: string;
  openOnWeekends: string;
  imagesModel: Array<{
    id: string;
    path: string;
  }>;
}
interface IRouteParams {
  id: string;
}
const Orphanage: React.FC = () => {
  const params = useParams<IRouteParams>();
  const [orphanage, setOrphanage] = useState<IOrphanage>();
  const [activeImageIndex, setActiveImageIndex] = useState(0);

  useEffect(() => {
    api.get(`orphanages/${params.id}`).then((response) => {
      setOrphanage(response.data);
    });
  }, [params.id]);

  if (!orphanage) {
    return <p>Carregando...</p>;
  }
  return (
    <PageOrphanage>
      <Sidebar />
      <main>
        <OrphanageDetails>
          <img
            src={orphanage.imagesModel[activeImageIndex].path}
            alt={orphanage.name}
          />
          <Images>
            {orphanage.imagesModel.map((image, index) => {
              return (
                <button
                  key={image.id}
                  type="button"
                  className={activeImageIndex === index ? "active" : ""}
                  onClick={() => {
                    setActiveImageIndex(index);
                  }}
                >
                  <img src={image.path} alt={orphanage.name} />
                </button>
              );
            })}
          </Images>
          <OrphanageDetailsContent>
            <h1>{orphanage.name}</h1>
            <p>{orphanage.about}</p>
            <MapContainerDiv>
              <Map>
                <MapTileLayer />
                <MapMarker />
              </Map>
              <footer>
                <a
                  target="_blank"
                  rel="noopener noreferrer"
                  href={`https://www.google.com/maps/dir/?api=1&destination=${orphanage.latitude},${orphanage.longitude}`}
                >
                  Ver rotas no Google Maps
                </a>
              </footer>
            </MapContainerDiv>
            <hr />
            <h2>Instruções para visita</h2>
            <p>{orphanage.instructions}</p>
            <OpenDetails>
              <Hour>
                <FiClock size={32} color="#15B6D6" />
                Segunda à Sexta <br />
                {orphanage.openingHours}
              </Hour>
              {orphanage.openOnWeekends ? (
                <OpenOnWeekends>
                  <FiInfo size={32} color="#39CC83" />
                  Atendemos <br />
                  fim de semana
                </OpenOnWeekends>
              ) : (
                <OpenOnWeekends className="dont-open">
                  <FiInfo size={32} color="#FF669D" />
                  Não atendemos <br />
                  fim de semana
                </OpenOnWeekends>
              )}
            </OpenDetails>
            <ContactButton>
              <FaWhatsapp size={20} color="#FFF" />
              Entrar em contato
            </ContactButton>
          </OrphanageDetailsContent>
        </OrphanageDetails>
      </main>
    </PageOrphanage>
  );
};

export default Orphanage;
