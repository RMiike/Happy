import styled from "styled-components";
import { MapContainer, Marker, TileLayer } from "react-leaflet";
import MapIcon from "../../utils/MapIcon";

export const PageCreateOrphanage = styled.div`
  display: flex;
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
export const InputBlock = styled.div`
  label {
    display: flex;
    color: #8fa7b3;
    margin-bottom: 8px;
    line-height: 24px;
    span {
      font-size: 14px;
      color: #8fa7b3;
      margin-left: 24px;
      line-height: 24px;
    }
  }
  input,
  textarea {
    width: 100%;
    background: #f5f8fa;
    border: 1px solid #d3e2e5;
    border-radius: 20px;
    outline: none;
    color: #5c8599;
  }
  input {
    height: 64px;
    padding: 0 16px;
  }
  textarea {
    min-height: 120px;
    max-height: 240px;
    resize: vertical;
    padding: 16px;
    line-height: 28px;
  }
  input[type="file"] {
    visibility: hidden;
  }
`;

export const CreateOrphanageForm = styled.form`
  width: 700px;
  margin: 64px auto;

  background: var(--tertiary-background-color);
  border: 1px solid var(--primary-border);
  border-radius: 20px;

  padding: 64px 80px;

  overflow: hidden;
  fieldset {
    border: 0;
  }
  fieldset + fieldset {
    margin-top: 80px;
  }
  fieldset legend {
    width: 100%;

    font-size: 32px;
    line-height: 34px;
    color: #5c8599;
    font-weight: 700;

    border-bottom: 1px solid #d3e2e5;
    margin-bottom: 40px;
    padding-bottom: 24px;
  }
  ${InputBlock} + ${InputBlock} {
    margin-top: 24px;
  }
  .leaflet-container {
    margin-bottom: 40px;
    border: 1px solid var(--primary-border);
    border-radius: 20px;
  }
`;
export const ImageContainer = styled.div`
  display: grid;
  grid-template-columns: repeat(5, 1fr);
  grid-gap: 16px;
  img {
    width: 100%;
    height: 96px;
    object-fit: cover;
    border-radius: 20px;
  }
`;
export const NewImage = styled.label`
  height: 96px;
  background: #f5f8fa;
  border: 1px dashed #96d2f0;
  border-radius: 20px;
  cursor: pointer;

  display: flex;
  justify-content: center;
  align-items: center;
`;
export const ButtonSelect = styled.div`
  display: grid;
  grid-template-columns: 1fr 1fr;
  button {
    height: 64px;
    background: #f5f8fa;
    border: 1px solid #d3e2e5;
    color: #5c8599;
    cursor: pointer;
  }
  .active {
    background: #edfff6;
    border: 1px solid #a1e9c5;
    color: #37c77f;
  }
  button:first-child {
    border-radius: 20px 0px 0px 20px;
  }
  button:last-child {
    border-radius: 0 20px 20px 0;
    border-left: 0;
  }
`;
export const ConfirmButton = styled.button`
  margin-top: 64px;

  width: 100%;
  height: 64px;
  border: 0;
  cursor: pointer;
  background: #3cdc8c;
  border-radius: 20px;
  color: #ffffff;
  font-weight: 800;

  display: flex;
  justify-content: center;
  align-items: center;

  transition: background-color 0.2s;
  svg {
    margin-right: 16px;
  }
  :hover {
    background: #36cf82;
  }
`;

export const Map = styled(MapContainer).attrs({
  zoom: 15,
})`
  width: 100%;
  height: 280px;
`;

export const MapTileLayer = styled(TileLayer).attrs({
  url: "https://a.tile.openstreetmap.org/{z}/{x}/{y}.png",
})``;

export const MapMarker = styled(Marker).attrs({
  interactive: false,
  icon: MapIcon,
})``;
