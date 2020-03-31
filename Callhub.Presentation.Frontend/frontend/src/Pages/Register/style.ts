import styled from "styled-components";

export const Container = styled.div`
  min-height: 120px;
  width: 600px;
  position: relative;
  background-color: ${props => props.theme.colors.background.card};
`;
