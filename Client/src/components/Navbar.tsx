import Navbar from 'react-bootstrap/Navbar';
import Button from 'react-bootstrap/Button';
import Container from 'react-bootstrap/Container';
import { NavbarBrand } from 'react-bootstrap';
import { Product } from './ProductTable';
import Toast from 'react-bootstrap/Toast';
import { useState } from 'react';

export function NavbarCustom({getAllProducts, setProducts}: {setProducts: Function, getAllProducts: Function}) {
    const [showA, setShowA] = useState(true);
    const toggleShowA = () => setShowA(!showA);
    return (
        <Navbar bg="dark" variant="dark">
        <Container>
          <NavbarBrand>
          <Button className="refreshProductsButton" variant="outline-success" onClick={() => getAllProducts().then((productList: Product) => setProducts(productList))}>Actualizar productos</Button>
          </NavbarBrand>
          <Navbar.Brand className="justify-content-start" href="/">GyF Challenge</Navbar.Brand>
          <Navbar.Collapse className="justify-content-end">
            <Navbar.Text>
              <img className="nav-logo" rel="icon" src="/icon.svg" />
            </Navbar.Text>
            <Toast show={showA} onClose={toggleShowA} className="toastyToast">
                <Toast.Header>
                    <img src="holder.js/20x20?text=%20" className="rounded me-2" alt="" />
                    <strong className="me-auto">GyF</strong>
                </Toast.Header>
                <Toast.Body>Bienvenidos al desafio!</Toast.Body>
            </Toast>
          </Navbar.Collapse>
        </Container>
      </Navbar>
    );
}