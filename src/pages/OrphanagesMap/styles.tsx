import styled from "styled-components";
import { Link } from "react-router-dom";
import mapMarkerImg from "../../assets/images/map-marker.svg";
import { Popup, MapContainer, TileLayer, Marker } from "react-leaflet";
import Leaflet from "leaflet";

const mapIcon = Leaflet.icon({
  iconUrl: mapMarkerImg,
  iconSize: [58, 68],
  iconAnchor: [29, 68],
  popupAnchor: [170, 2],
});

export const PageMap = styled.div`
  width: 100vw;
  height: 100vh;
  position: relative;
  display: flex;
  aside {
    width: 440px;
    background: linear-gradient(
      329.54deg,
      var(--primary-landing-color-one) 0%,
      var(--primary-landing-color-two) 100%
    );
    padding: 80px;
    display: flex;
    flex-direction: column;
    justify-content: space-between;
    h2 {
      font-size: 48px;
      font-weight: 800;
      line-height: 42px;
      margin-top: 64px;
    }
    p {
      line-height: 28px;
      margin-top: 24px;
    }
    footer {
      display: flex;
      flex-direction: column;
      line-height: 24px;

      strong {
        font-weight: 800;
      }
    }
  }
`;
export const CreateOrphanage = styled(Link)`
  z-index: 100;
  position: absolute;
  right: 40px;
  bottom: 40px;
  width: 64px;
  height: 64px;
  background: var(--primary-buttom-color-two);
  border-radius: 20px;
  display: flex;
  justify-content: center;
  align-items: center;
  transition: background-color 0.2s;
  &&:hover {
    background: var(--secondary-buttom-color-two);
  }
`;
export const MapPopup = styled(Popup).attrs({
  maxWidth: 240,
  minWidth: 240,
  closeButton: false,
})`
  .leaflet-popup-content-wrapper {
    background: rgba(255, 255, 255, 0.8);
    border-radius: 20px;
    box-shadow: none;
  }
  .leaflet-popup-content {
    color: var(--primary-buttom-popup-map);
    font-size: 20px;
    font-weight: bold;
    margin: 8px 12px;
    display: flex;
    justify-content: space-between;
    align-items: center;
  }
  .leaflet-popup-content a {
    width: 40px;
    height: 40px;
    background: var(--primary-buttom-color-two);
    box-shadow: var(--primary-box-shadow);

    border-radius: 12px;
    display: flex;
    justify-content: center;
    align-items: center;
  }
  .leaflet-popup-tip-container {
    display: none;
  }
`;

export const Map = styled(MapContainer).attrs({
  center: [-15.8305799, -48.0383723],
  zoom: 15,
})`
  width: 100%;
  height: 100%;
  z-index: 1;
`;

export const MapTileLayer = styled(TileLayer).attrs({
  url: "https://a.tile.openstreetmap.org/{z}/{x}/{y}.png",
})``;

export const MapMarker = styled(Marker).attrs({
  icon: mapIcon,
})``;
