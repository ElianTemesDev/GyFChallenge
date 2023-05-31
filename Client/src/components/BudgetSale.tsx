import Button from 'react-bootstrap/Button';
import Form from 'react-bootstrap/Form';
import { GetSale } from '../Api';
import { useState } from 'react';
import { Col, Row } from 'react-bootstrap';

export function BudgetSale() {
  const [budget, setBudget] = useState(0);
  const [saleResult, setSaleResult] = useState("");

  return (
    <>
        <Form onSubmit={ (e) => { e.preventDefault(); GetSale(budget).then(data => data === undefined ? "" : setSaleResult(data))} }>
            <Row>
                <Col xs={3}>
                    <Form.Group className="mb-3" controlId="formBasicPrice">
                        <Form.Label>Precio del producto</Form.Label>
                        <Form.Control
                            type="number" min="1" max="1000" step="1" required placeholder="Ingrese el presupuesto para la compra." 
                            onChange={e => setBudget(parseInt(e.target.value))}
                        />
                        <Form.Text className="text-muted">
                        Maximo 1000
                        </Form.Text>
                    </Form.Group>
                </Col>
            </Row>
            <Button variant="primary" type="submit" value="Submit">
                Realizar venta.
            </Button>
        </Form>
        <p className="budgetResult text-center badge bg-dark text-wrap">{saleResult}</p>
    </>
  );
}