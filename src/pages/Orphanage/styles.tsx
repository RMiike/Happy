import styled from "styled-components";
import { MapContainer, TileLayer, Marker } from "react-leaflet";
import MapIcon from "../../utils/MapIcon";

export const PageOrphanage = styled.div`
  display: flex;
  min-height: 100vh;
  aside {
    position: fixed;
    height: 100%;
    padding: 32px 24px;
    background: linear-gradient(var(--secondary-background-color));

    display: flex;
    flex-direction: column;
    justify-content: space-between;
    align-items: center;
    img {
      width: 48px;
    }
    footer a,
    footer button {
      width: 48px;
      height: 48px;

      border: 0;

      background: var(--quaternary-button-color-one);
      border-radius: 16px;

      cursor: pointer;

      transition: background-color 0.2s;

      display: flex;
      justify-content: center;
      align-items: center;
    }
    footer a:hover,
    footer button:hover {
      background: var(--quaternary-button-color-two);
    }
  }
  main {
    flex: 1;
  }
`;
export const OrphanageDetails = styled.div`
  width: 700px;
  margin: 64px auto;

  background: var(--tertiary-background-color);
  border: 1px solid var(--primary-border);
  border-radius: 20px;

  overflow: hidden;
  > img {
    width: 100%;
    height: 300px;
    object-fit: cover;
  }
`;

export const Images = styled.div`
  display: grid;
  grid-template-columns: repeat(6, 1fr);
  column-gap: 16px;

  margin: 16px 40px 0;
  button {
    border: 0;
    height: 88px;
    background: none;
    cursor: pointer;
    border-radius: 20px;
    overflow: hidden;
    outline: none;

    opacity: 0.6;
    img {
      width: 100%;
      height: 88px;
      object-fit: cover;
    }
  }
  .active {
    opacity: 1;
  }
`;
export const OrphanageDetailsContent = styled.div`
  padding: 80px;
  h1 {
    color: var(--secondary-text-color);
    font-size: 54px;
    line-height: 54px;
    margin-bottom: 8px;
  }
  p {
    line-height: 28px;
    color: var(--tertiary-text-color);
    margin-top: 24px;
  }
  hr {
    width: 100%;
    height: 1px;
    border: 0;
    background: var(--primary-border);
    margin: 64px 0;
  }
  h2 {
    font-size: 36px;
    line-height: 46px;
    color: var(--secondary-text-color);
  }
`;
export const MapContainerDiv = styled.div`
  margin-top: 64px;
  background: var(--tertiary-background-color-two);
  border: 1px solid var(--tertiary-border);
  border-radius: 20px;

  .leaflet-container {
    border-bottom: 1px solid var(--secondary-border);
    border-radius: 20px;
  }

  footer {
    padding: 20px 0;
    text-align: center;
  }
  footer a {
    line-height: 24px;
    color: var(--primary-buttom-popup-map);
    text-decoration: none;
  }
`;

export const Map = styled(MapContainer).attrs({
  center: [-15.8305799, -48.0383723],
  zoom: 15,
  dragging: false,
  touchZoom: false,
  zoomControl: false,
  scrollWheelZoom: false,
  doubleClickZoom: false,
})`
  width: 100%;
  height: 280px;
  z-index: 1;
`;
export const MapTileLayer = styled(TileLayer).attrs({
  url: "https://a.tile.openstreetmap.org/{z}/{x}/{y}.png",
})``;
export const MapMarker = styled(Marker).attrs({
  interactive: false,
  icon: MapIcon,
  position: [-15.8305799, -48.0383723],
})``;

export const OpenDetails = styled.div`
  margin-top: 24px;

  display: grid;
  grid-template-columns: 1fr 1fr;
  column-gap: 20px;
  div {
    padding: 32px 24px;
    border-radius: 20px;
    line-height: 28px;
  }
  svg {
    display: block;
    margin-bottom: 20px;
  }
`;
export const Hour = styled.div`
  background: linear-gradient(var(--fourfy-background-color));
  border: 1px solid var(--tertiary-border);
  color: var(--tertiary-text-color);
`;

export const OpenOnWeekends = styled.div`
  background: linear-gradient(
    ${(props) =>
      props.className === "dont-open"
        ? "154.16deg, #fdf0f5 7.85%, #ffffff 91.03%"
        : "154.16deg, #edfff6 7.85%, #ffffff 91.03%"}
  );
  border: 1px solid
    ${(props) => (props.className === "dont-open" ? "#ff669d" : "#a1e9c5")};
  color: ${(props) =>
    props.className === "dont-open" ? "#ff669d" : "#a1e9c5"};
`;
export const ContactButton = styled.button`
  margin-top: 64px;

  width: 100%;
  height: 64px;
  border: 0;
  cursor: pointer;
  background: var(--tertiary-button-color-tree);
  border-radius: 20px;
  color: var(--tertiary-background-color);
  font-weight: 800;

  display: flex;
  justify-content: center;
  align-items: center;

  transition: background-color 0.2s;
  svg {
    margin-right: 16px;
  }
  :hover {
    background: var(--tertiary-button-color-four);
  }
`;
